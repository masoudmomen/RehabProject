using AutoMapper;
using Rehab.Application.Common;
using Rehab.Application.Contexts;
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
        BaseDto<FacilityDto> Add(FacilityDto facility); 
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
        public BaseDto<FacilityDto> Add(FacilityDto facility)
        {
            if (facility == null) return BaseDto<FacilityDto>.FailureResult("The Facility data is null!");

            context.Facilities.Add(mapper.Map<Facility>(facility));
            if (context.SaveChanges() > 0)
                return BaseDto<FacilityDto>.SuccessResult(facility, "Facility Added Successfully.");

            return BaseDto<FacilityDto>.FailureResult("Operation Failed! Please try another time!");
        }
    }
}
