using Infrastructure.Model.Interfaces;

namespace BakeryApp.Model.DTOs.FoodMaterial.Get
{
    public class FoodMaterialNameGetDto : IDto
    {
        public int Id { get; set; }
        public string Material { get; set; }
    }
}
