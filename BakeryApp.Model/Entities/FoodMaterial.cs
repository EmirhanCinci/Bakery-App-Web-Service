using Infrastructure.Model.Implementations;

namespace BakeryApp.Model.Entities
{
    public class FoodMaterial : Entity<int>
    {
        public int FoodId { get; set; }
        public string Material { get; set; }

        // Navigation Property
        public virtual Food Food { get; set; }
    }
}
