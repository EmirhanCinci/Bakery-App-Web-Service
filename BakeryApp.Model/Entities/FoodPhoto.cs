using Infrastructure.Model.Implementations;

namespace BakeryApp.Model.Entities
{
    public class FoodPhoto : Entity<int>
    {
        public int FoodId { get; set; }
        public string PhotoPath { get; set; }

        // Navigation Property
        public virtual Food Food { get; set; }
    }
}
