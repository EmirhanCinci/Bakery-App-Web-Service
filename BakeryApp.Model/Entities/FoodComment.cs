using Infrastructure.Model.Implementations;

namespace BakeryApp.Model.Entities
{
    public class FoodComment : Entity<int>
    {
        public int UserId { get; set; }
        public int FoodId { get; set; }
        public string Text { get; set; }
        public string Photo { get; set; }
        public int Points { get; set; }

        // Navigation Property
        public virtual Food Food { get; set; }
        public virtual User User { get; set; }
    }
}
