using Infrastructure.Model.Interfaces;

namespace BakeryApp.Model.DTOs.UserBasket.Post
{
    public class UserBasketPostDto : IDto
    {
        public int UserId { get; set; }
        public int FoodId { get; set; }
    }
}
