using Infrastructure.Model.Implementations;

namespace BakeryApp.Model.DTOs.FoodPhoto.Get
{
    public class FoodPhotoGetDto : Dto<int>
    {
        public string FoodName { get; set; }
        public string PhotoPath { get; set; }
    }
}
