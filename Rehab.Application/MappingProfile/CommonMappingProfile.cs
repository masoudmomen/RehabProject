using AutoMapper;
using Rehab.Application.Accreditations;
using Rehab.Application.Amenities;
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
using Rehab.Domain.Facilities;
using Rehab.Domain.Highlights;
using Rehab.Domain.Insurances;
using Rehab.Domain.LevelsOfCare;
using Rehab.Domain.SubstancesWeTreat;
using Rehab.Domain.Tags;
using Rehab.Domain.Treatments;
using Rehab.Domain.Users;
using Rehab.Domain.WhoWeTreat;
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
            CreateMap<Facility, AddRequestFacilityDto>().ReverseMap();
            CreateMap<Insurance, InsuranceDto>().ReverseMap();
            CreateMap<Accreditation, AccreditationDto>().ReverseMap();
            CreateMap<Amenity, AmenityDto>().ReverseMap()
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.Tags)); 
            CreateMap<Highlight, HighlightDto>().ReverseMap();
            CreateMap<Wwt, WwtDto>().ReverseMap();
            CreateMap<Loc, LevelsOfCareDto>().ReverseMap();
            CreateMap<Treatment, TreatmentDto>().ReverseMap();
            CreateMap<Condition, ConditionDto>().ReverseMap();
            CreateMap<Swt, SwtDto>().ReverseMap();
            CreateMap<Treatment, TreatmentDto>().ReverseMap();
            CreateMap<Tag,TagDto>().ReverseMap();
        }
    }
}
