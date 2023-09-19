using Infrastructure.Model.Interfaces;

namespace BakeryApp.Model.DTOs.FoodMaterial.Put
{
    public class FoodMaterialPutDto : IDto
    {
        public int Id { get; set; }
        public int FoodId { get; set; }
        public string Material { get; set; }
    }
}
