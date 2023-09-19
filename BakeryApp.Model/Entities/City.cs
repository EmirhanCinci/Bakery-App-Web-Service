using Infrastructure.Model.Implementations;

namespace BakeryApp.Model.Entities
{
    public class City : Entity<int>
    {
        public string Name { get; set; }
        public int CountryId { get; set; }

        // Navigation Property
        public virtual ICollection<User> Users { get; set; }
        public virtual Country Country { get; set; }
    }
}
