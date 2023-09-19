using Infrastructure.Model.Interfaces;

namespace BakeryApp.Model.DTOs.OrderDetail.Post
{
    public class OrderDetailPostDto : IDto
    {
        public int OrderId { get; set; }
        public int FoodId { get; set; }
        public double Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
