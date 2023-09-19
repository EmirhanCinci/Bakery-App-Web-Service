using Infrastructure.Model.Implementations;

namespace BakeryApp.Model.Entities
{
    public class UserFavorite : Entity<int>
    {
        public int UserId { get; set; }
        public int FoodId { get; set; }

        // Navigation Property
        public virtual Food Food { get; set; }
        public virtual User User { get; set; }
    }
}
