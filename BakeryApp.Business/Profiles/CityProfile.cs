using AutoMapper;
using BakeryApp.Model.DTOs.City.Get;
using BakeryApp.Model.DTOs.City.Post;
using BakeryApp.Model.DTOs.City.Put;
using BakeryApp.Model.Entities;

namespace BakeryApp.Business.Profiles
{
    public class CityProfile : Profile
    {
        public CityProfile() 
        {
            CreateMap<City, CityGetDto>().ReverseMap();

            CreateMap<CityPostDto, City>();
            CreateMap<CityPutDto, City>();
        }
    }
}
