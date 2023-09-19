using AutoMapper;
using BakeryApp.Model.DTOs.Gender.Get;
using BakeryApp.Model.Entities;

namespace BakeryApp.Business.Profiles
{
    public class GenderProfile : Profile
    {
        public GenderProfile() 
        {
            CreateMap<Gender, GenderGetDto>().ReverseMap();
        }
    }
}
