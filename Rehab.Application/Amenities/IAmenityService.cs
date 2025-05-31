using AutoMapper;
using Rehab.Application.Common;
using Rehab.Application.Contexts;
using Rehab.Application.Insurances;
using Rehab.Domain.Amenities;
using Rehab.Domain.Insurances;
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

            context.Amenities.Add(mapper.Map<Amenity>(amenity));
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
            return mapper.Map<List<AmenityDto>>(context.Amenities.ToList());
        }

        public BaseDto<AmenityDto> Update(AmenityDto amenity)
        {
            if (amenity == null) return BaseDto<AmenityDto>.FailureResult("The Amenity data is null!");

            var amenityForUpdate = context.Amenities.Find(amenity.Id);
            if (amenityForUpdate is null) return BaseDto<AmenityDto>.FailureResult("The Amenity not find!");

            if (amenity.Logo == "") amenity.Logo = amenityForUpdate.Logo;
            mapper.Map(amenity, amenityForUpdate);
            if (context.SaveChanges() > 0) return BaseDto<AmenityDto>.SuccessResult(amenity, "Amenity Updated successfully.");

            return BaseDto<AmenityDto>.FailureResult("Operation Failed! Please try another time!");
        }
    }

    public class AmenityDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Logo { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
