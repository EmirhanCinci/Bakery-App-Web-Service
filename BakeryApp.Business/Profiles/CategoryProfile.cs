using AutoMapper;
using BakeryApp.Model.DTOs.Category.Get;
using BakeryApp.Model.DTOs.Category.Post;
using BakeryApp.Model.DTOs.Category.Put;
using BakeryApp.Model.Entities;

namespace BakeryApp.Business.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile() 
        {
            CreateMap<Category, CategoryGetDto>().ReverseMap();
            CreateMap<CategoryPostDto, Category>();
            CreateMap<CategoryPutDto, Category>();
        }
    }
}
