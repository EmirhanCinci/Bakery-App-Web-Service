using Infrastructure.Model.Implementations;

namespace BakeryApp.Model.DTOs.FoodMaterial.Get
{
    public class FoodMaterialGetDto : Dto<int>
    {
        public string FoodName { get; set; }
        public string Material { get; set; }
    }
}
