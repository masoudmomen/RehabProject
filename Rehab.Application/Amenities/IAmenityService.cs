using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rehab.Application.Common;
using Rehab.Application.Contexts;
using Rehab.Application.Insurances;
using Rehab.Application.Tags;
using Rehab.Domain.Amenities;
using Rehab.Domain.Insurances;
using Rehab.Domain.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehab.Application.Amenities
{
    public interface IAmenityService
    {
        BaseDto<AmenityDto> Add(AmenityDto insurance);
        List<AmenityDto> GetList();
        BaseDto<AmenityDto> Update(AmenityDto insurance);

        BaseDto<AmenityDto> Delete(AmenityDto insurance);
    }

    public class AmenityService : IAmenityService
    {
        private readonly IDatabaseContext context;
        private readonly IMapper mapper;

        public AmenityService(IDatabaseContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public BaseDto<AmenityDto> Add(AmenityDto amenity)
        {

            if (amenity == null) return BaseDto<AmenityDto>.FailureResult("The Amenity data is null!");
            var finalTags = new List<Tag>();
            foreach(var tagDto in amenity.Tags.ToList())
            {
                var tagName = tagDto.Name;
                
                var existingTag = context.Tags.FirstOrDefault(t => t.Name == tagName);
                if (existingTag == null) {
                    existingTag = mapper.Map<Tag>(tagDto);
                    existingTag.Name = tagName;
                    context.Tags.Add(existingTag);
                    context.SaveChanges();
                }
                finalTags.Add(existingTag);
               
            }
            var amenityEntity = mapper.Map<Amenity>(amenity);
            amenityEntity.Tags = finalTags;
            context.Amenities.Add(amenityEntity);
            if (context.SaveChanges() > 0) return BaseDto<AmenityDto>.SuccessResult(amenity, "Amenity Added successfully.");

            return BaseDto<AmenityDto>.FailureResult("Operation Failed! Please try another time!");
        }

        public BaseDto<AmenityDto> Delete(AmenityDto amenity)
        {
            if (amenity is null) return BaseDto<AmenityDto>.FailureResult("The Amenity data is null!");

            var result = context.Amenities.FirstOrDefault(c => c.Id == amenity.Id);
            if (result == null) return BaseDto<AmenityDto>.FailureResult("The Amenity not find!");

            context.Amenities.Remove(result);
            if (context.SaveChanges() > 0) return BaseDto<AmenityDto>.SuccessResult(amenity, "Amenity Deleted successfully.");

            return BaseDto<AmenityDto>.FailureResult("Operation Failed! Please try another time!");
        }

        public List<AmenityDto> GetList()
        {
            return mapper.Map<List<AmenityDto>>
                (context.Amenities
                .Include(a => a.Tags)
                .OrderBy(c => c.Name).ToList());
        }

        public BaseDto<AmenityDto> Update(AmenityDto amenity)
        {
               
            if (amenity == null) return BaseDto<AmenityDto>.FailureResult("The Amenity data is null!");

            var amenityForUpdate = context.Amenities
                .Include(a => a.Tags)
                .FirstOrDefault(a => a.Id == amenity.Id);
            if (amenityForUpdate is null) return BaseDto<AmenityDto>.FailureResult("The Amenity not found!");

            if (amenity.Logo == "") amenity.Logo = amenityForUpdate.Logo;

            amenityForUpdate.Name = amenity.Name;
            amenityForUpdate.Description = amenity.Description;
            amenityForUpdate.Logo = amenity.Logo;

            amenityForUpdate.Tags.Clear();

            if (amenity.Tags != null)
            {
                foreach(var tagDto in amenity.Tags)
                {
                    var existingTag = context.Tags.Find(tagDto.Id);
                    if(existingTag != null)
                    {
                        amenityForUpdate.Tags.Add(existingTag);
                    }
                }
            }

            if (context.SaveChanges() > 0) { 
                var updatedDto = mapper.Map<AmenityDto>(amenityForUpdate);
                return BaseDto<AmenityDto>.SuccessResult(amenity, "Amenity Updated successfully."); 
                
            }

            return BaseDto<AmenityDto>.FailureResult("Operation Failed! Please try another time!");
        }
    }

    public class AmenityDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Logo { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<TagDto> Tags { get; set; } = new();
    }
}
