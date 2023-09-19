using Infrastructure.Model.Implementations;

namespace BakeryApp.Model.DTOs.UserFavorite.Get
{
    public class UserFavoriteGetDto : Entity<int>
    {
        public string UserFullName { get; set; }
        public string FoodName { get; set; }
    }
}
