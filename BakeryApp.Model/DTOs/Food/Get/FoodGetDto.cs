using BakeryApp.Model.DTOs.FoodMaterial.Get;
using Infrastructure.Model.Implementations;

namespace BakeryApp.Model.DTOs.Food.Get
{
    public class FoodGetDto : Dto<int>
    {
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public bool IsStock { get; set; }
    }
}
