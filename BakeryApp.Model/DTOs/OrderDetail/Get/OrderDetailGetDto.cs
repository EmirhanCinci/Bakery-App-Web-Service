using Infrastructure.Model.Implementations;

namespace BakeryApp.Model.DTOs.OrderDetail.Get
{
    public class OrderDetailGetDto : Dto<int>
    {
        public int OrderId { get; set; }
        public string FoodName { get; set; }
        public double Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
