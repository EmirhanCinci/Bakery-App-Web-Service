using AutoMapper;
using BakeryApp.Model.DTOs.Food.Get;
using BakeryApp.Model.DTOs.Food.Post;
using BakeryApp.Model.DTOs.Food.Put;
using BakeryApp.Model.Entities;

namespace BakeryApp.Business.Profiles
{
    public class FoodProfile : Profile
    {
        public FoodProfile() 
        {
            CreateMap<Food, FoodGetDto>();
            CreateMap<Food, SingleFoodGetDto>();

            CreateMap<FoodPostDto, Food>();
            CreateMap<FoodPutDto, Food>();
        }
    }
}
