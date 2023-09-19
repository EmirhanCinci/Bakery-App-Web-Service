using Infrastructure.Model.Interfaces;

namespace BakeryApp.Model.DTOs.UserFavorite.Post
{
    public class UserFavoritePostDto : IDto
    {
        public int UserId { get; set; }
        public int FoodId { get; set; }
    }
}
