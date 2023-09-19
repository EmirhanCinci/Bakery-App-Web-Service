using Infrastructure.Model.Interfaces;

namespace BakeryApp.Model.DTOs.FoodPhoto.Get
{
    public class FoodPhotoSingleGetDto : IDto
    {
        public int Id { get; set; }
        public string PhotoPath { get; set; }
    }
}
