using AutoMapper;
using Common;
using Rehab.Application.Common;
using Rehab.Application.Contexts;
using Rehab.Application.Dtos;
using Rehab.Domain.Facilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehab.Application.Facilities
{
    public interface IFacilityService
    {
        BaseDto<AddRequestFacilityDto> Add(AddRequestFacilityDto facility); 
        Task<PaginatedItemDto<FacilityBriefInfoDto>> GetFacilities(int page, int pageSize);
    }

    public class FacilityService : IFacilityService
    {
        private readonly IDatabaseContext context;
        private readonly IMapper mapper;

        public FacilityService(IDatabaseContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public BaseDto<AddRequestFacilityDto> Add(AddRequestFacilityDto facility)
        {
            if (facility == null) return BaseDto<AddRequestFacilityDto>.FailureResult("The Facility data is null!");

            var newFacility = new Facility();
            newFacility = mapper.Map<Facility>(facility);

            newFacility.Insurances = context.Insurances.Where(c => facility.InsurancesId!.Contains(c.Id)).ToList(); 
            newFacility.Accreditations = context.Accreditations.Where(c => facility.AccreditationsId!.Contains(c.Id)).ToList(); 
            newFacility.Amenities = context.Amenities.Where(c => facility.AmenitiesId!.Contains(c.Id)).ToList(); 
            newFacility.Highlights = context.Highlights.Where(c => facility.HighlightsId!.Contains(c.Id)).ToList(); 
            newFacility.Locs = context.Locs.Where(c => facility.LocsId!.Contains(c.Id)).ToList(); 
            newFacility.Wwts = context.Wwts.Where(c => facility.WwtsId!.Contains(c.Id)).ToList(); 
            newFacility.Treatments = context.Treatments.Where(c => facility.TreatmentsId!.Contains(c.Id)).ToList(); 

            context.Facilities.Add(newFacility);

            if (context.SaveChanges() > 0)
                return BaseDto<AddRequestFacilityDto>.SuccessResult(facility, "Facility Added Successfully.");

            return BaseDto<AddRequestFacilityDto>.FailureResult("Operation Failed! Please try another time!");
        }

        public async Task<PaginatedItemDto<FacilityBriefInfoDto>> GetFacilities(int page, int pageSize)
        {
            int rowCount = 0;
            var data = context.Facilities
                .OrderByDescending(c => c.Id)
                .ToPaged(page, pageSize, out rowCount)
                .Select(c=> new FacilityBriefInfoDto
                {
                    Name = c.Name,
                    Id = c.Id,
                    City = c.City,
                    State = c.State,
                    Description = c.Description,
                    Logo = c.Logo,
                }).ToList();
            return new PaginatedItemDto<FacilityBriefInfoDto>(page, pageSize, rowCount, data);
        }
    }
}
