using AutoMapper;
using BakeryApp.Model.DTOs.FoodMaterial.Get;
using BakeryApp.Model.DTOs.FoodMaterial.Post;
using BakeryApp.Model.DTOs.FoodMaterial.Put;
using BakeryApp.Model.Entities;

namespace BakeryApp.Business.Profiles
{
    public class FoodMaterialProfile : Profile
    {
        public FoodMaterialProfile()
        {
            CreateMap<FoodMaterial, FoodMaterialGetDto>();
            CreateMap<FoodMaterial, FoodMaterialNameGetDto>();

            CreateMap<FoodMaterialPostDto, FoodMaterial>();
            CreateMap<FoodMaterialPutDto, FoodMaterial>();
        }
    }
}
