using Infrastructure.Model.Implementations;

namespace BakeryApp.Model.DTOs.Order.Get
{
    public class OrderGetDto : Dto<int>
    {
        public string UserFullName { get; set; }
        public Guid TrackingNumber { get; set; }
        public decimal Price { get; set; }
    }
}
