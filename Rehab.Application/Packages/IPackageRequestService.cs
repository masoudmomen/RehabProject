using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Rehab.Application.Amenities;
using Rehab.Application.Blog;
using Rehab.Application.Common;
using Rehab.Application.Contexts;
using Rehab.Application.Dtos;
using Rehab.Application.PaymentLinks;
using Rehab.Application.Tags;
using Rehab.Domain.Packages;
using Rehab.Domain.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace Rehab.Application.Packages
{
    public interface IPackageRequestService
    {
        BaseDto<PackageRequestDto> Add(PackageRequestDto packageRequest);
        Task<PaginatedItemDto<PackageRequestDto>> GetListAsync(int page, int pageSize);
        BaseDto<PackageRequestDto> Delete(PackageRequestDto request);
        Task<BaseDto<PackageRequestDto>> GetByIdAsync(int id);
        BaseDto<PackageRequestDto> ChangeStatus(int id, string status);
    }

    public class PackageRequestService : IPackageRequestService
    {
        private readonly IDatabaseContext _context;
        private readonly IMapper _mapper;
        private readonly IOptions<PaymentLinksOptions> _paymentLinksOptions;

        public PackageRequestService(
            IDatabaseContext context,
            IMapper mapper,
            IOptions<PaymentLinksOptions> paymentLinksOptions)
        {
            _context = context;
            _mapper = mapper;
            _paymentLinksOptions = paymentLinksOptions;
        }
        public BaseDto<PackageRequestDto> Add(PackageRequestDto requestDto)
        {
            if (requestDto == null) return BaseDto<PackageRequestDto>.FailureResult("The package request is null!");

            requestDto.CreatedDate = DateTime.Now;

            _context.PackageRequests.Add(_mapper.Map<PackageRequest>(requestDto));
            if (_context.SaveChanges() > 0)
                return BaseDto<PackageRequestDto>.SuccessResult(requestDto, "Package request created successfully!");

            return BaseDto<PackageRequestDto>.FailureResult("Operation Faild! please try another time!");
        }

        public async Task<PaginatedItemDto<PackageRequestDto>> GetListAsync(int page, int pageSize)
        {
            var query = _context.PackageRequests
                 .AsNoTracking();

            var rowCount = await query.CountAsync();

            var data = await query
                .OrderByDescending(r => r.CreatedDate)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<PackageRequestDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            if (data.Count > 0)
            {
                var requestIds = data.Select(d => d.Id).ToList();

                // Fetch latest payment link for each request
                var LastPaymentLinks = await _context.PaymentLinks
                    .AsNoTracking()
                    .Where(p => requestIds.Contains(p.PackageRequestId))
                    .GroupBy(p => p.PackageRequestId)
                    .Select(g => g
                        .OrderByDescending(x => x.CreatedAt)
                        .Select(x => new PaymentLinkDto
                        {
                            PackageRequestId = x.PackageRequestId,
                            Token = x.Token,
                            Amount = x.Amount,
                            CreatedAt = x.CreatedAt,
                            LinkExpiresAt = x.LinkExpiresAt,
                            IsUsed = x.IsUsed,

                        })
                        .FirstOrDefault()
                    )
                    .ToListAsync();

                var latestByRequest = LastPaymentLinks
                   .Where(x => x != null)
                   .ToDictionary(x => x!.PackageRequestId);
                foreach(var item in data)
                {
                    if(latestByRequest.TryGetValue(item.Id, out var link))
                    {
                        item.LastPaymentLink = link;
                    }
                }

            }

            return new PaginatedItemDto<PackageRequestDto>(
                page,
                pageSize,
                rowCount,
                data
            );
        }

        public BaseDto<PackageRequestDto> Delete(PackageRequestDto request)
        {
            if (request is null) return BaseDto<PackageRequestDto>.FailureResult("The Request data is null!");

            var result = _context.PackageRequests.FirstOrDefault(c => c.Id == request.Id);
            if (result == null) return BaseDto<PackageRequestDto>.FailureResult("The Request not find!");

            _context.PackageRequests.Remove(result);
            if (_context.SaveChanges() > 0) return BaseDto<PackageRequestDto>.SuccessResult(request, "Request Deleted successfully.");

            return BaseDto<PackageRequestDto>.FailureResult("Operation Failed! Please try another time!");
        }

        public async Task<BaseDto<PackageRequestDto>> GetByIdAsync(int id)
        {
            var result = await _context.PackageRequests
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);
            if (result == null) return BaseDto<PackageRequestDto>.FailureResult("The Request not find!");
            var resultDto = _mapper.Map<PackageRequestDto>(result);
            return BaseDto<PackageRequestDto>.SuccessResult(resultDto, "Successfull");

        }
        public BaseDto<PackageRequestDto> ChangeStatus(int id, string status)
        {
            var request = _context.PackageRequests.FirstOrDefault(pr => pr.Id == id);
            if (request is null) return BaseDto<PackageRequestDto>.FailureResult("The Request data is null!");

            if (!Enum.TryParse<RequestStatus>(status, ignoreCase: true, out var parsedStatus))
                return BaseDto<PackageRequestDto>.FailureResult("The status value is not valid!");

            request.RequestStatus = parsedStatus;
            _context.SaveChanges();

            var resultDto = _mapper.Map<PackageRequestDto>(request);
            return BaseDto<PackageRequestDto>.SuccessResult(resultDto, "Status changed successfully!");
        }

    }
}

