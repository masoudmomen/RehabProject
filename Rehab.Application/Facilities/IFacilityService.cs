using AutoMapper;
using Common;
using Microsoft.EntityFrameworkCore;
using Rehab.Application.Common;
using Rehab.Application.Contexts;
using Rehab.Application.Dtos;
using Rehab.Domain.Facilities;
using Rehab.Domain.Images;
using Rehab.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Rehab.Application.Facilities
{
    public interface IFacilityService
    {
        BaseDto<AddRequestFacilityDto> Add(AddRequestFacilityDto facility); 
        Task<PaginatedItemDto<FacilityBriefInfoDto>> GetFacilities(int page, int pageSize);
        Task<PaginatedItemDto<FacilityBriefInfoDto>> GetFacilities(int page, int pageSize, string searchText);
        FacilityDetailDto? FindById(int id);
        BaseDto<AddRequestFacilityDto> Update(AddRequestFacilityDto facility);
        BaseDto<SetFacilityImagesDto> SetFacilitiesImage(SetFacilityImagesDto facilityImages);
        SetFacilityImagesDto? GetFacilitiesImage(int FacilityId);
        bool SetFacilityLogo(int id,string facilityLogo);
        bool SetFacilityCover(int id,string facilityCover);
        int? SetFacilityImages(int id,string facilityImage, string imageTitle);
        bool RemoveFacilityImage(int facilityId, int  imageId);
        List<FacilityNameSlugDto> SetSlug();
        List<FacilityCardDto>? GetRandomFacilityCardForHomePage(int CardCount);
        Task<(List<FacilityCardDto>, int totalCount)> GetFacilitiesAsync(int pageNumber, int pageSize);
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
            if (facility == null) return BaseDto<AddRequestFacilityDto>.FailureResult("Facility data is null!");
            if (context.Facilities.FirstOrDefault(c => c.Slug == facility.Slug) != null)
            {
                var result = new BaseDto<AddRequestFacilityDto>()
                {
                    Data = facility,
                    Message = "This Slug is exist, Change it!",
                    Success = false,
                    Status = "slug"
                };
                return result;
            }
            var newFacility = new Facility();
            newFacility = mapper.Map<Facility>(facility);

            newFacility.Insurances = context.Insurances.Where(c => facility.InsurancesId!.Contains(c.Id)).ToList(); 
            newFacility.Accreditations = context.Accreditations.Where(c => facility.AccreditationsId!.Contains(c.Id)).ToList(); 
            newFacility.Amenities = context.Amenities.Where(c => facility.AmenitiesId!.Contains(c.Id)).ToList(); 
            newFacility.Highlights = context.Highlights.Where(c => facility.HighlightsId!.Contains(c.Id)).ToList(); 
            newFacility.Locs = context.Locs.Where(c => facility.LocsId!.Contains(c.Id)).ToList(); 
            newFacility.Wwts = context.Wwts.Where(c => facility.WwtsId!.Contains(c.Id)).ToList(); 
            newFacility.Treatments = context.Treatments.Where(c => facility.TreatmentsId!.Contains(c.Id)).ToList(); 
            newFacility.Conditions = context.Conditions.Where(c => facility.ConditionsId!.Contains(c.Id)).ToList(); 
            newFacility.Swts = context.Swts.Where(c => facility.SwtsId!.Contains(c.Id)).ToList(); 

            context.Facilities.Add(newFacility);

            if (context.SaveChanges() > 0)
                return BaseDto<AddRequestFacilityDto>.SuccessResult(facility, "Facility Added Successfully.");

            return BaseDto<AddRequestFacilityDto>.FailureResult("Operation Failed! Please try another time!");
        }

        public BaseDto<AddRequestFacilityDto> Update(AddRequestFacilityDto facility)
        {
            if (facility == null) return BaseDto<AddRequestFacilityDto>.FailureResult("Facility data is null!");

            var facilityForUpdate = context.Facilities
                .Where(c => c.Id == facility.Id)
                .Include(c => c.Insurances)
                .Include(c => c.Accreditations)
                .Include(c => c.Amenities)
                .Include(c => c.Highlights)
                .Include(c => c.Locs)
                .Include(c => c.Wwts)
                .Include(c => c.Treatments)
                .Include(c => c.Conditions)
                .Include(c => c.Swts)
                .FirstOrDefault();
            if (facilityForUpdate == null) return BaseDto<AddRequestFacilityDto>.FailureResult("This Facility is not Exist!");

            facilityForUpdate = mapper.Map(facility, facilityForUpdate);
          
            facilityForUpdate.Insurances = context.Insurances.Where(c => facility.InsurancesId!.Contains(c.Id)).ToList();
            facilityForUpdate.Accreditations = context.Accreditations.Where(c => facility.AccreditationsId!.Contains(c.Id)).ToList();
            facilityForUpdate.Amenities = context.Amenities.Where(c => facility.AmenitiesId!.Contains(c.Id)).ToList();
            facilityForUpdate.Highlights = context.Highlights.Where(c => facility.HighlightsId!.Contains(c.Id)).ToList();
            facilityForUpdate.Locs = context.Locs.Where(c => facility.LocsId!.Contains(c.Id)).ToList();
            facilityForUpdate.Wwts = context.Wwts.Where(c => facility.WwtsId!.Contains(c.Id)).ToList();
            facilityForUpdate.Treatments = context.Treatments.Where(c => facility.TreatmentsId!.Contains(c.Id)).ToList();
            facilityForUpdate.Conditions = context.Conditions.Where(c => facility.ConditionsId!.Contains(c.Id)).ToList();
            facilityForUpdate.Swts = context.Swts.Where(c => facility.SwtsId!.Contains(c.Id)).ToList();
         
           
            if (context.SaveChanges() > 0)
                return BaseDto<AddRequestFacilityDto>.SuccessResult(facility, "Facility Updated Successfully.");
            return BaseDto<AddRequestFacilityDto>.FailureResult("Operation Failed! Please try another time!");
        }
        public FacilityDetailDto? FindById(int id)
        {
            
            var facility = context.Facilities
            .AsSplitQuery()
            .Where(c => c.Id == id)
            .Include(c => c.Insurances)
            .Include(c => c.Accreditations)
            .Include(c => c.Highlights)
            .Include(c => c.Amenities)
            .Include(c => c.Wwts)
            .Include(c => c.Treatments)
            .Include(c => c.FacilitysImages)
            .Include(c => c.Locs)
            .Include(c => c.Conditions)
            .Include(c => c.Swts)
            .Select(c => new FacilityDetailDto
            {
                Id = c.Id,
                Name = c.Name,
                Address = c.Address,
                Logo = c.Logo,
                Cover = c.Cover,
                Description = c.Description,
                City = c.City,
                Email = c.Email,
                Founded = c.Founded,
                IsVerified = c.IsVerified,
                OccupancyMax = c.OccupancyMax,
                OccupancyMin = c.OccupancyMin,
                PhoneNumber = c.PhoneNumber,
                ProvidersPolicy = c.ProvidersPolicy,
                Slug = c.Slug,
                State = c.State,
                WebSite = c.WebSite,
                FacilitysImages = c.FacilitysImages!
                    .Select(img => new FacilityImageDto
                    {
                        Id = img.Id,
                        ImageAddress = img.ImageAddress,
                        Title = img.Title
                    }).ToList(),

                Accreditations = c.Accreditations!.ToList(),
                Highlights = c.Highlights!.ToList(),
                Amenities = c.Amenities!.ToList(),
                Treatments = c.Treatments!.ToList(),
                Wwts = c.Wwts!.ToList(),
                Insurances = c.Insurances!.ToList(),
                Locs = c.Locs!.ToList(),
                Conditions = c.Conditions!.ToList(),
                Swts = c.Swts!.ToList(),
            })
            .FirstOrDefault();

            return facility;
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

        public SetFacilityImagesDto? GetFacilitiesImage(int FacilityId)
        {
            return context.Facilities
            .Where(c => c.Id == FacilityId)
            .Include(c => c.FacilitysImages)
            .Select(c => new SetFacilityImagesDto
            {
                Cover = c.Cover,
                Logo = c.Logo,
                FacilityId = c.Id,
                FacilityImages = c.FacilitysImages!.Select(d => new FacilityImagesDto
                {
                    Id = d.Id,
                    ImageAddress = d.ImageAddress,
                    Title = d.Title,
                }).ToList(),
            })
            .FirstOrDefault();
        }

        public bool RemoveFacilityImage(int facilityId, int imageId)
        {
            var facility = context.Facilities.FirstOrDefault(f => f.Id == facilityId);
            if (facility == null) return false;
            var facilityImage = context.FacilitysImages.FirstOrDefault(f => f.Id == imageId);
            if (facility.FacilitysImages == null || facilityImage == null) return false;
            facility.FacilitysImages.Remove(facilityImage);
            if (context.SaveChanges() > 0)
            {
                context.FacilitysImages.Remove(facilityImage);
                if (context.SaveChanges()>0)
                    return true;
            }
            return false;
        }

        public BaseDto<SetFacilityImagesDto> SetFacilitiesImage(SetFacilityImagesDto facilityImages)
        {
            if (facilityImages == null) return BaseDto<SetFacilityImagesDto>.FailureResult("Images data is null!") ;
            var facilityForUpdate = context.Facilities.FirstOrDefault(c => c.Id == facilityImages.FacilityId);
            if (facilityForUpdate == null) return BaseDto<SetFacilityImagesDto>.FailureResult("This Facility is not Exist!");
            facilityImages.Logo = facilityForUpdate.Logo;
            facilityImages.Cover = facilityForUpdate.Cover;
            if(facilityImages.FacilityImages != null && facilityImages.FacilityImages.Count>0)
                foreach (var item in facilityImages.FacilityImages)
                {
                    facilityForUpdate.FacilitysImages!.Add(new Domain.Images.FacilitysImages
                    {
                        Facility = facilityForUpdate,
                        ImageAddress = item.ImageAddress,
                        Title = item.Title,
                    });
                }
            if (context.SaveChanges() > 0)
                return BaseDto<SetFacilityImagesDto>.SuccessResult(facilityImages, "Images Uploaded Successfully.");
            return BaseDto<SetFacilityImagesDto>.FailureResult("Images Upload Failed!");
        }

        public bool SetFacilityCover(int id, string facilityCover)
        {
            var facility = context.Facilities.FirstOrDefault(f => f.Id == id);
            if (facility == null) return false;
            facility.Cover = facilityCover;
            context.SaveChanges();
            if (context.SaveChanges() > 0) return true;
            return false;
        }

        public int? SetFacilityImages(int id, string facilityImage, string imageTitle)
        {
            var facility = context.Facilities.Where(f => f.Id == id).Include(c=>c.FacilitysImages).FirstOrDefault();
            if (facility == null) return null;
            FacilitysImages NewFacilityImage = new FacilitysImages()
            {
                ImageAddress = facilityImage,
                Facility = facility,
                Title = imageTitle
            };
            facility.FacilitysImages!.Add(NewFacilityImage);
            if (context.SaveChanges() > 0) return NewFacilityImage.Id;
            return null;
        }

        public bool SetFacilityLogo(int id, string facilityLogo)
        {
            var facility = context.Facilities.FirstOrDefault(f => f.Id == id);
            if (facility == null) return false;
            facility.Logo = facilityLogo;
            context.SaveChanges();
            if(context.SaveChanges() > 0) return true;
            return false;
        }

        public async Task<PaginatedItemDto<FacilityBriefInfoDto>> GetFacilities(int page, int pageSize, string searchText)
        {
            int rowCount = 0;
            var data = context.Facilities.Where(c=>c.Name.Contains(searchText))
                .OrderByDescending(c => c.Id)
                .ToPaged(page, pageSize, out rowCount)
                .Select(c => new FacilityBriefInfoDto
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

        public List<FacilityCardDto>? GetRandomFacilityCardForHomePage(int CardCount)
        {
            return context.Facilities
                    .Include(c=>c.FacilitysImages)
                    .Include(c=>c.Insurances)
                    .Include(c=>c.Accreditations)
                    .Include(c=>c.Wwts)
                    .Include(c=>c.Swts)
                    .Include(c=>c.Amenities)
                    .Include(c=>c.Conditions)
                    .Include(c=>c.Highlights)
                    .Include(c=>c.Locs)
                    .Include(c=>c.Treatments)
                    .Where(c=>c.Logo != "" && c.FacilitysImages.Count>0)
                    .Select(c=> new FacilityCardDto() {
                        Id = c.Id,
                        Name = c.Name,
                        Address = (string.IsNullOrEmpty(c.State)?"No State":c.State),
                        Logo = c.Logo,
                        Cover = c.Cover,
                        CardImage = c.FacilitysImages!.Select(f=>f.ImageAddress).FirstOrDefault(),
                        AccreditationCount = c.Accreditations!.Count(),
                        AmenityCount = c.Amenities!.Count(),
                        ConditionCount = c.Conditions!.Count(),
                        HighlightCount = c.Highlights!.Count(),
                        InsuranceCount = c.Insurances!.Count(),
                        SwtCount = c.Swts!.Count(),
                        TreatmentCount = c.Treatments!.Count(),
                        WwtCount = c.Wwts!.Count(),
                    }).Take(CardCount).ToList();
        }

        public List<FacilityNameSlugDto> SetSlug()
        {
            var model = new List<FacilityNameSlugDto>();
            foreach (var item in context.Facilities.Where(c=>string.IsNullOrEmpty(c.Slug)))
            {
                var text = item.Name;
                text = text.ToLowerInvariant();
                //حذف کاراکترهای غیر از حرف ، عدد و فاصله
                text = Regex.Replace(text, @"[^a-z0-9\s-]", "");
                text = Regex.Replace(text, @"\s+", "-");
                text = Regex.Replace(text, @"-+", "-");
                text = text.Trim('-');
                item.Slug = text;
                model.Add(new FacilityNameSlugDto { FacilityName = item.Name, FacilitySlug = item.Slug });
            }
            if(context.SaveChanges()>0) return model;
            return new List<FacilityNameSlugDto>();
        }

        public async Task<(List<FacilityCardDto>, int totalCount)> GetFacilitiesAsync(int pageNumber, int pageSize)
        {
            var query = context.Facilities.Where(c => c.Logo != "" && c.FacilitysImages.Count > 0).AsQueryable();
            var totalCount = await query.CountAsync();
            var facilities = await query
                .OrderBy(c=>c.Id)
                .Skip((pageNumber-1) * pageSize)
                .Take(pageSize)
                .Include(c => c.FacilitysImages)
                .Include(c => c.Insurances)
                .Include(c => c.Accreditations)
                .Include(c => c.Wwts)
                .Include(c => c.Swts)
                .Include(c => c.Amenities)
                .Include(c => c.Conditions)
                .Include(c => c.Highlights)
                .Include(c => c.Locs)
                .Include(c => c.Treatments)
                .Select(c => new FacilityCardDto()
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Address = (string.IsNullOrEmpty(c.State) ? "No State" : c.State),
                        Logo = c.Logo,
                        Cover = c.Cover,
                        CardImage = c.FacilitysImages!.Select(f => f.ImageAddress).FirstOrDefault(),
                        AccreditationCount = c.Accreditations!.Count(),
                        AmenityCount = c.Amenities!.Count(),
                        ConditionCount = c.Conditions!.Count(),
                        HighlightCount = c.Highlights!.Count(),
                        InsuranceCount = c.Insurances!.Count(),
                        SwtCount = c.Swts!.Count(),
                        TreatmentCount = c.Treatments!.Count(),
                        WwtCount = c.Wwts!.Count(),
                    }).ToListAsync();
            return (facilities, totalCount);
        }
    }

    public class FacilityNameSlugDto
    {
        public string FacilityName { get; set; } = string.Empty;
        public string FacilitySlug { get; set; } = string.Empty;
    }
}
