using Infrastructure.Model.Implementations;

namespace BakeryApp.Model.Entities
{
    public class Category : Entity<int>
    {
        public string Name { get; set; }

        // Navigation Property
        public virtual ICollection<Food> Foods { get; set; }
    }
}
