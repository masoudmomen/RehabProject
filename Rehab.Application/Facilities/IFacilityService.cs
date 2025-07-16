using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rehab.Application.Common;
using Rehab.Application.Contexts;
using Rehab.Application.Dtos;
using Rehab.Domain.Facilities;
using Rehab.Infrastructure;
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

        FacilityDetailDto? FindById(int id);
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

        public FacilityDetailDto? FindById(int id)
        {
            var facility = context.Facilities.FirstOrDefault(c => c.Id == id);
            if(facility == null) return null;
            return context.Facilities.Where(c=>c.Id == id)
                .Include(c => c.Insurances)
                .Include(c => c.Accreditations)
                .Include(c => c.Highlights)
                .Include(c => c.Amenities)
                .Include(c => c.Wwts)
                .Include(c => c.Treatments)
                .Include(c => c.FacilitysImages)
                .Include(c => c.Locs)
                .Select(c => new FacilityDetailDto
                {
                    Id = id,
                    Name = c.Name,
                    Address = c.Address,
                    IsVerified = c.IsVerified,
                    Logo = c.Logo,
                    Founded = c.Founded,
                    OccupancyMax = c.OccupancyMax,
                    OccupancyMin = c.OccupancyMin,
                    PhoneNumber = c.PhoneNumber,
                    City = c.City,
                    Cover = c.Cover,
                    Description = c.Description,
                    Email = c.Email,
                    ProvidersPolicy = c.ProvidersPolicy,
                    Slug = c.Slug,
                    State = c.State,
                    WebSite = c.WebSite,
                    Accreditations = c.Accreditations!.ToList(),
                    Highlights = c.Highlights!.ToList(),
                    Amenities = c.Amenities!.ToList(),
                    FacilitysImages = c.FacilitysImages!.ToList(),
                    Treatments = c.Treatments!.ToList(),
                    Wwts = c.Wwts!.ToList(),
                    Insurances = c.Insurances!.ToList(),
                    Locs = c.Locs!.ToList() 
                }).FirstOrDefault();
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
