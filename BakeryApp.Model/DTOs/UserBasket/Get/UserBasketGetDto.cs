using Infrastructure.Model.Implementations;

namespace BakeryApp.Model.DTOs.UserBasket.Get
{
    public class UserBasketGetDto : Dto<int>
    {
        public string UserFullName { get; set; }
        public string FoodName { get; set; }
    }
}
