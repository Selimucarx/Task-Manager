using AutoMapper;
using TaskManager.Dtos;
using TaskManager.Models;

namespace TaskManager.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, RegisterUserDto>().ReverseMap();
            CreateMap<User, LoginUserDto>().ReverseMap();
        }
    }
}