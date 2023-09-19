using AutoMapper;
using BakeryApp.Model.DTOs.Country.Get;
using BakeryApp.Model.DTOs.Country.Post;
using BakeryApp.Model.DTOs.Country.Put;
using BakeryApp.Model.Entities;

namespace BakeryApp.Business.Profiles
{
    public class CountryProfile : Profile
    {
        public CountryProfile() 
        {
            CreateMap<Country, CountryGetDto>().ReverseMap();

            CreateMap<CountryPostDto, Country>();
            CreateMap<CountryPutDto, Country>();
        }
    }
}
