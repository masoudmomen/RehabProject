using AutoMapper;
using Rehab.Application.Facilities;
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
        }

    }
}
