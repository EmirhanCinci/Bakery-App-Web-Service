using AutoMapper;
using BakeryApp.Model.DTOs.OrderDetail.Get;
using BakeryApp.Model.DTOs.OrderDetail.Post;
using BakeryApp.Model.Entities;

namespace BakeryApp.Business.Profiles
{
    public class OrderDetailProfile : Profile
    {
        public OrderDetailProfile() 
        {
            CreateMap<OrderDetail, OrderDetailGetDto>();

            CreateMap<OrderDetailPostDto, OrderDetail>();
        }
    }
}
