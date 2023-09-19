using Infrastructure.Model.Interfaces;

namespace BakeryApp.Model.DTOs.FoodPhoto.Post
{
    public class FoodPhotoPostDto : IDto
    {
        public int FoodId { get; set; }
        public string PhotoPath { get; set; }
    }
}
