using Infrastructure.Model.Implementations;

namespace BakeryApp.Model.Entities
{
    public class Country : Entity<int>
    {
        public string Name { get; set; }

        // Navigation Property
        public virtual ICollection<City> Cities { get; set; }
    }
}
