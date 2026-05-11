using AutoMapper;
using Rehab.Application.Common;
using Rehab.Application.Contexts;
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
    }

    public class PackageRequestService : IPackageRequestService
    {
        private readonly IDatabaseContext _context;
        private readonly IMapper _mapper;
        public PackageRequestService(IDatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public BaseDto<PackageRequestDto> Add(PackageRequestDto requestDto)
        {
            if (requestDto == null) return BaseDto<PackageRequestDto>.FailureResult("The package request is null!");

            _context.PackageRequests.Add(_mapper.Map<PackageRequest>(requestDto));
            if (_context.SaveChanges() > 0)
                return BaseDto<PackageRequestDto>.SuccessResult(requestDto, "Package request created successfully!");

            return BaseDto<PackageRequestDto>.FailureResult("Operation Faild! please try another time!");
        }
    }

    public class PackageRequestDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? CenterName { get; set; }
        public string? Message { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public PackageType PackageType { get; set; }
        public RequestStatus RequestStatus { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
