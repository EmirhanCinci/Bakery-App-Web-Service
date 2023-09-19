using Infrastructure.Model.Implementations;

namespace BakeryApp.Model.Entities
{
    public class Food : Entity<int>
    {
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public bool IsStock { get; set; }

        // Navigation Property
        public virtual Category Category { get; set; }
        public virtual ICollection<FoodComment> FoodComments { get; set; }
        public virtual ICollection<FoodMaterial> FoodMaterials { get; set; }
        public virtual ICollection<FoodPhoto> FoodPhotos { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<UserBasket> UserBaskets { get; set; }
        public virtual ICollection<UserFavorite> UserFavorites { get; set; }
    }
}
