using Infrastructure.Model.Interfaces;

namespace BakeryApp.Model.DTOs.Category.Put
{
    public class CategoryPutDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
