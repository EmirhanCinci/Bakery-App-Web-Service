using Infrastructure.Model.Interfaces;

namespace BakeryApp.Model.DTOs.Order.Post
{
    public class OrderPostDto : IDto
    {
        public int UserId { get; set; }
        public decimal Price { get; set; }
    }
}
