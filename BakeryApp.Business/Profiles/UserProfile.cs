using AutoMapper;
using BakeryApp.Model.DTOs.User.Get;
using BakeryApp.Model.DTOs.User.Post;
using BakeryApp.Model.DTOs.User.Put;
using Infrastructure.Model.Implementations;
using Infrastructure.Utilities.Security.Hashing;

namespace BakeryApp.Business.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<User, UserGetDto>();

            CreateMap<UserPostDto, User>();
            CreateMap<UserPutDto, User>();
        }
    }
}
