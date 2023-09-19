using AutoMapper;
using BakeryApp.Model.DTOs.FoodPhoto.Get;
using BakeryApp.Model.DTOs.FoodPhoto.Post;
using BakeryApp.Model.DTOs.FoodPhoto.Put;
using BakeryApp.Model.Entities;

namespace BakeryApp.Business.Profiles
{
    public class FoodPhotoProfile : Profile
    {
        public FoodPhotoProfile() 
        {
            CreateMap<FoodPhoto, FoodPhotoGetDto>();
            CreateMap<FoodPhoto, FoodPhotoSingleGetDto>();

            CreateMap<FoodPhotoPostDto, FoodPhoto>();
            CreateMap<FoodPhotoPutDto, FoodPhoto>();
        }
    }
}
