using AutoMapper;
using Rehab.Application.Contexts;
using Rehab.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehab.Application.Users
{
    public interface IUserService
    {
        UserDto? Add(UserDto user);
        List<UserDto>? GetAll();
    }

    public class UserService : IUserService
    {
        private readonly IDatabaseContext context;
        private readonly IMapper mapper;

        public UserService(IDatabaseContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public UserDto? Add(UserDto user)
        {
            if (user == null) return null;
            var newUser = mapper.Map<User>(user);
            context.Users.Add(newUser);
            context.SaveChanges();
            return mapper.Map<UserDto>(newUser);
        }

        public List<UserDto>? GetAll()
        {
            return mapper.Map<List<UserDto>>(context.Users);
        }
    }

    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
