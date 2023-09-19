using Infrastructure.Model.Interfaces;

namespace BakeryApp.Model.DTOs.FoodMaterial.Post
{
    public class FoodMaterialPostDto : IDto
    {
        public int FoodId { get; set; }
        public string Material { get; set; }
    }
}
