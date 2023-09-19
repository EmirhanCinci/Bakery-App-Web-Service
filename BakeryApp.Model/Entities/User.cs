using BakeryApp.Model.Entities;
using Infrastructure.Model.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Model.Implementations
{
    public class User : Entity<int>, IUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int CityId { get; set; }
        public int GenderId { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        [NotMapped]
        public string FullName { get { return $"{FirstName} {LastName}"; } }

        // Navigation Property
        public virtual City City { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual ICollection<UserBasket> UserBaskets { get; set; }
        public virtual ICollection<UserFavorite> UserFavorites { get; set; }
        public virtual ICollection<FoodComment> FoodComments { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
