using AutoMapper;
using Rehab.Application.Facilities;
using Rehab.Application.Insurances;
using Rehab.Application.Users;
using Rehab.Domain.Facilities;
using Rehab.Domain.Insurances;
using Rehab.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Rehab.Infrastructure.MappingProfile
{
    public class CommonMappingProfile: Profile
    {
        public CommonMappingProfile() 
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Facility, FacilityDto>().ReverseMap();
            CreateMap<Insurance, InsuranceDto>().ReverseMap();
        }
    }
}
