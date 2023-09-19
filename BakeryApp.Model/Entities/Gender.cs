using Infrastructure.Model.Implementations;

namespace BakeryApp.Model.Entities
{
    public class Gender : Entity<int>
    {
        public string Name { get; set; }

        // Navigation Property
        public virtual ICollection<User> Users { get; set; }
    }
}
