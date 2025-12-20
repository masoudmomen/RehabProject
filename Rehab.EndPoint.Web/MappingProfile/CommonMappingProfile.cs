using AutoMapper;
using Rehab.Application.Accreditations;
using Rehab.Application.Amenities;
using Rehab.Application.Conditions;
using Rehab.Application.Facilities;
using Rehab.Application.Highlights;
using Rehab.Application.Insurances;
using Rehab.Application.LevelsOfCare;
using Rehab.Application.SubstancesWeTreat;
using Rehab.Application.Treatments;
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
using Rehab.EndPoint.Web.ViewModels;
using AccreditationViewmodel = Rehab.EndPoint.Web.ViewModels.AccreditationViewmodel;
using AmenityViewmodel = Rehab.EndPoint.Web.ViewModels.AmenityViewmodel;
using HighlightViewmodel = Rehab.EndPoint.Web.ViewModels.HighlightViewmodel;
using LocViewmodel = Rehab.EndPoint.Web.ViewModels.LocViewmodel;
using TreatmentViewmodel = Rehab.EndPoint.Web.ViewModels.TreatmentViewmodel;

namespace Rehab.EndPoint.Web.MappingProfile
{
    public class CommonMappingProfile : Profile
    {
        public CommonMappingProfile()
        {
            CreateMap<FacilityCardDto, FacilityCardViewmodel>().ReverseMap();
            CreateMap<FacilityDetailDto, FacilityViewModel>().ReverseMap();

            CreateMap<ViewModels.InsuranceViewModel, Insurance>().ReverseMap();
            CreateMap<AccreditationViewmodel, Accreditation>().ReverseMap();
            CreateMap<ViewModels.AmenityViewmodel, Amenity>().ReverseMap();
            CreateMap<ViewModels.HighlightViewmodel, Highlight>().ReverseMap();
            CreateMap<ViewModels.FacilityImageViewmodel, FacilitysImages>().ReverseMap();
            CreateMap<ViewModels.FacilityImageViewmodel, FacilityImageDto>().ReverseMap();
            CreateMap<ViewModels.LocViewmodel, Loc>().ReverseMap();
            CreateMap<ViewModels.TreatmentViewmodel, Treatment>().ReverseMap();
            CreateMap<WwtViewModel, Wwt>().ReverseMap();
            CreateMap<SwtViewModel, Swt>().ReverseMap();
            CreateMap<ConditionViewModel, Condition>().ReverseMap();
            CreateMap<ViewModels.FacilityImageViewmodel, FacilityImageDto>().ReverseMap();

            CreateMap<InsuranceDto, InsuranceViewmodel>().ReverseMap();
            CreateMap<AccreditationDto, AccreditationViewmodel>().ReverseMap();
            CreateMap<AmenityDto, AmenityViewmodel>().ReverseMap();
            CreateMap<HighlightDto, HighlightViewmodel>().ReverseMap();
            CreateMap<WwtDto, WwtViewmodel>().ReverseMap();
            CreateMap<LevelsOfCareDto, LocViewmodel>().ReverseMap();
            CreateMap<TreatmentDto, TreatmentViewmodel>().ReverseMap();
            CreateMap<ConditionDto, ConditionViewmodel>().ReverseMap();
            CreateMap<SwtDto, SwtViewmodel>().ReverseMap();

            CreateMap<AmenityViewmodel, Amenity>().ReverseMap();
            CreateMap<AmenityViewmodel, AmenityDto>()
            .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Tags));

            CreateMap<AmenityDto, AmenityViewmodel>()
            .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Tags));
        }

    }
}
