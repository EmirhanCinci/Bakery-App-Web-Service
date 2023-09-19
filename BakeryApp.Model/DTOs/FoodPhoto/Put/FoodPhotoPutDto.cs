using Infrastructure.Model.Interfaces;

namespace BakeryApp.Model.DTOs.FoodPhoto.Put
{
    public class FoodPhotoPutDto : IDto
    {
        public int Id { get; set; }
        public int FoodId { get; set; }
        public string PhotoPath { get; set; }
    }
}
