using Infrastructure.Model.Interfaces;

namespace BakeryApp.Model.DTOs.Food.Post
{
    public class FoodPostDto : IDto
    {
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public bool IsStock { get; set; }
    }
}
