using AutoMapper;
using Rehab.Application.Accreditations;
using Rehab.Application.Amenities;
using Rehab.Application.Common;
using Rehab.Application.Facilities;
using Rehab.Application.Highlights;
using Rehab.Application.Insurances;
using Rehab.Application.LevelsOfCare;
using Rehab.Application.Treatments;
using Rehab.Application.Users;
using Rehab.Application.WhoWeTreat;
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
            CreateMap<AccreditationDto, AccreditationViewmodel>().ReverseMap();
            CreateMap<AmenityDto, AmenityViewmodel>().ReverseMap();
            CreateMap<HighlightDto, HighlightViewmodel>().ReverseMap();
            CreateMap<WwtDto, WwtViewmodel>().ReverseMap();
            CreateMap<LevelsOfCareDto, LocViewmodel>().ReverseMap();
            CreateMap<TreatmentDto, TreatmentViewmodel>().ReverseMap();
            CreateMap(typeof(BaseDto<>), typeof(ResultViewmodel<>))
            .ForMember("Data", opt => opt.MapFrom("Data"))
            .ForMember("Success", opt => opt.MapFrom("Success"))
            .ForMember("Message", opt => opt.MapFrom("Message"))
            .ForMember("Status", opt => opt.MapFrom("Status")).ReverseMap();
        }

    }
}
