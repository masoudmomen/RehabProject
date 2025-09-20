using AutoMapper;
using Rehab.Application.Facilities;
using Rehab.EndPoint.Web.ViewModels;

namespace Rehab.EndPoint.Web.MappingProfile
{
    public class CommonMappingProfile : Profile
    {
        public CommonMappingProfile()
        {
            CreateMap<FacilityCardDto, FacilityCardViewmodel>().ReverseMap();
        }

    }
}
