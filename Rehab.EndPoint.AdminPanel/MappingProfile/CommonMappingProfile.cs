using AutoMapper;
using Rehab.Application.Users;
using Rehab.EndPoint.AdminPanel.Viewmodels;

namespace Rehab.EndPoint.AdminPanel.MappingProfile
{
    public class CommonMappingProfile: Profile
    {
        public CommonMappingProfile()
        {
            CreateMap<UserDto, UserViewmodel>().ReverseMap();
        }

    }
}
