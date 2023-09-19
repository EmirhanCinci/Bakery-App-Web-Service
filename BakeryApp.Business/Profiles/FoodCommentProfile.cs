using AutoMapper;
using BakeryApp.Model.DTOs.FoodComment.Get;
using BakeryApp.Model.DTOs.FoodComment.Post;
using BakeryApp.Model.DTOs.FoodComment.Put;
using BakeryApp.Model.Entities;

namespace BakeryApp.Business.Profiles
{
    public class FoodCommentProfile : Profile
    {
        public FoodCommentProfile() 
        {
            CreateMap<FoodComment, FoodCommentGetDto>();
            CreateMap<FoodComment, FoodCommentTextGetDto>();

            CreateMap<FoodCommentPostDto, FoodComment>();
            CreateMap<FoodCommentPutDto, FoodComment>();
        }
    }
}
