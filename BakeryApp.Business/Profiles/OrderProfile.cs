using AutoMapper;
using BakeryApp.Model.DTOs.Order.Get;
using BakeryApp.Model.DTOs.Order.Post;
using BakeryApp.Model.Entities;

namespace BakeryApp.Business.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile() 
        {
            CreateMap<Order, OrderGetDto>();

            CreateMap<OrderPostDto, Order>();
        }
    }
}
