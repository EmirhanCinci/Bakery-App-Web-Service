using AutoMapper;
using BakeryApp.Model.DTOs.UserFavorite.Get;
using BakeryApp.Model.DTOs.UserFavorite.Post;
using BakeryApp.Model.Entities;

namespace BakeryApp.Business.Profiles
{
    public class UserFavoriteProfile : Profile
    {
        public UserFavoriteProfile() 
        {
            CreateMap<UserFavorite, UserFavoriteGetDto>();

            CreateMap<UserFavoritePostDto, UserFavorite>();
        }
    }
}
