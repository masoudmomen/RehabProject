using AutoMapper;
using Rehab.Application.Common;
using Rehab.Application.Facilities;
using Rehab.Application.Insurances;
using Rehab.Application.Users;
using Rehab.EndPoint.AdminPanel.Viewmodels;

namespace Rehab.EndPoint.AdminPanel.MappingProfile
{
    public class CommonMappingProfile: Profile
    {
        public CommonMappingProfile()
        {
            CreateMap<UserDto, UserViewmodel>().ReverseMap();
            CreateMap<FacilityDto, FacilityViewmodel>().ReverseMap();
            CreateMap<InsuranceDto, InsuranceViewmodel>().ReverseMap();
            //CreateMap(typeof(ResultViewmodel<>), typeof(BaseDto<>)).ReverseMap();
            CreateMap(typeof(BaseDto<>), typeof(ResultViewmodel<>))
            .ForMember("Data", opt => opt.MapFrom("Data"))
            .ForMember("Success", opt => opt.MapFrom("Success"))
            .ForMember("Message", opt => opt.MapFrom("Message"))
            .ForMember("Status", opt => opt.MapFrom("Status")).ReverseMap();
        }

    }
}
