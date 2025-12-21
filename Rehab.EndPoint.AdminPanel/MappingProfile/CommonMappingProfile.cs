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

            CreateMap<FacilityDetailDto, FacilityViewmodel>()
            .ForMember(dest => dest.InsurancesId, opt => opt.MapFrom(src => src.Insurances != null ? src.Insurances.Select(i => i.Id) : new List<int>()))
            .ForMember(dest => dest.AccreditationsId, opt => opt.MapFrom(src => src.Accreditations != null ? src.Accreditations.Select(i => i.Id) : new List<int>()))
            .ForMember(dest => dest.AmenitiesId, opt => opt.MapFrom(src => src.Amenities != null ? src.Amenities.Select(i => i.Id) : new List<int>()))
            .ForMember(dest => dest.HighlightsId, opt => opt.MapFrom(src => src.Highlights != null ? src.Highlights.Select(i => i.Id) : new List<int>()))
            .ForMember(dest => dest.LocsId, opt => opt.MapFrom(src => src.Locs != null ? src.Locs.Select(i => i.Id) : new List<int>()))
            .ForMember(dest => dest.TreatmentsId, opt => opt.MapFrom(src => src.Treatments != null ? src.Treatments.Select(i => i.Id) : new List<int>()))
            .ForMember(dest => dest.WwtsId, opt => opt.MapFrom(src => src.Wwts != null ? src.Wwts.Select(i => i.Id) : new List<int>()))
            .ForMember(dest => dest.ConditionsId, opt => opt.MapFrom(src => src.Conditions != null ? src.Conditions.Select(i => i.Id) : new List<int>()))
            .ForMember(dest => dest.SwtsId, opt => opt.MapFrom(src => src.Swts != null ? src.Swts.Select(i => i.Id) : new List<int>()))
            .ReverseMap();


            CreateMap<FacilityImagesViewmodel, FacilityImagesDto>().ReverseMap();
            CreateMap<SetFacilityImagesViewmodel, SetFacilityImagesDto>().ReverseMap();


        }

    }
}
