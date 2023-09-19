using AutoMapper;
using BakeryApp.Model.DTOs.UserBasket.Get;
using BakeryApp.Model.DTOs.UserBasket.Post;
using BakeryApp.Model.Entities;

namespace BakeryApp.Business.Profiles
{
    public class UserBasketProfile : Profile
    {
        public UserBasketProfile() 
        {
            CreateMap<UserBasket, UserBasketGetDto>();

            CreateMap<UserBasketPostDto, UserBasket>();
        }
    }
}
