using Infrastructure.Model.Implementations;

namespace BakeryApp.Model.Entities
{
    public class OrderDetail : Entity<int>
    {
        public int OrderId { get; set; }
        public int FoodId { get; set; }
        public double Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        // Navigation Property
        public virtual Order Order { get; set; }
        public virtual Food Food { get; set; }
    }
}
