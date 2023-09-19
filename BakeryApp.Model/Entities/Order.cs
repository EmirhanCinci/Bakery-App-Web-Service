using Infrastructure.Model.Implementations;

namespace BakeryApp.Model.Entities
{
    public class Order : Entity<int>
    {
        public int UserId { get; set; }
        public Guid TrackingNumber { get; set; }
        public decimal Price { get; set; }

        // Navigation Property
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual User User { get; set; }
    }
}
