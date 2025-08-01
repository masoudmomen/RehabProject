using AutoMapper;
using Rehab.Application.Accreditations;
using Rehab.Application.Amenities;
using Rehab.Application.Common;
using Rehab.Application.Conditions;
using Rehab.Application.Facilities;
using Rehab.Application.Highlights;
using Rehab.Application.Insurances;
using Rehab.Application.LevelsOfCare;
using Rehab.Application.SubstancesWeTreat;
using Rehab.Application.Tags;
using Rehab.Application.Treatments;
using Rehab.Application.Users;
using Rehab.Application.WhoWeTreat;
using Rehab.Domain.Accreditations;
using Rehab.Domain.Amenities;
using Rehab.Domain.Conditions;
using Rehab.Domain.Highlights;
using Rehab.Domain.Images;
using Rehab.Domain.Insurances;
using Rehab.Domain.LevelsOfCare;
using Rehab.Domain.SubstancesWeTreat;
using Rehab.Domain.Treatments;
using Rehab.Domain.WhoWeTreat;
using Rehab.EndPoint.AdminPanel.Viewmodels;

namespace Rehab.EndPoint.AdminPanel.MappingProfile
{
    public class CommonMappingProfile : Profile
    {
        public CommonMappingProfile()
        {
            CreateMap<UserDto, UserViewmodel>().ReverseMap();
            CreateMap<FacilityViewmodel, AddRequestFacilityDto>().ReverseMap();
            CreateMap<FacilityViewmodel, AddRequestFacilityDto>().ReverseMap();

            CreateMap<InsuranceDto, InsuranceViewmodel>().ReverseMap();
            CreateMap<AccreditationDto, AccreditationViewmodel>().ReverseMap();
            CreateMap<AmenityDto, AmenityViewmodel>().ReverseMap();
            CreateMap<HighlightDto, HighlightViewmodel>().ReverseMap();
            CreateMap<WwtDto, WwtViewmodel>().ReverseMap();
            CreateMap<LevelsOfCareDto, LocViewmodel>().ReverseMap();
            CreateMap<TreatmentDto, TreatmentViewmodel>().ReverseMap();
            CreateMap<ConditionDto, ConditionViewmodel>().ReverseMap();
            CreateMap<SwtDto, SwtViewmodel>().ReverseMap();

            CreateMap<InsuranceViewmodel, Insurance>().ReverseMap();
            CreateMap<AccreditationViewmodel, Accreditation>().ReverseMap();
            CreateMap<AmenityViewmodel, Amenity>().ReverseMap();
            CreateMap<HighlightViewmodel, Highlight>().ReverseMap();
            CreateMap<FacilityImageViewmodel, FacilitysImages>().ReverseMap();
            CreateMap<LocViewmodel, Loc>().ReverseMap();
            CreateMap<TreatmentViewmodel, Treatment>().ReverseMap();
            CreateMap<WwtViewmodel, Wwt>().ReverseMap();
            CreateMap<SwtViewmodel, Swt>().ReverseMap();
            CreateMap<ConditionViewmodel, Condition>().ReverseMap();
            CreateMap<TagViewModel, TagDto>().ReverseMap();
            CreateMap<AmenityViewmodel, AmenityDto>()
            .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Tags));

            CreateMap<AmenityDto, AmenityViewmodel>()
            .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Tags));

            CreateMap(typeof(BaseDto<>), typeof(ResultViewmodel<>))
            .ForMember("Data", opt => opt.MapFrom("Data"))
            .ForMember("Success", opt => opt.MapFrom("Success"))
            .ForMember("Message", opt => opt.MapFrom("Message"))
            .ForMember("Status", opt => opt.MapFrom("Status")).ReverseMap();

            CreateMap<FacilityViewmodel, FacilityDetailDto>().ReverseMap();


            CreateMap<FacilityImagesViewmodel, FacilityImagesDto>().ReverseMap();
            CreateMap<SetFacilityImagesViewmodel, SetFacilityImagesDto>().ReverseMap();


        }

    }
}
