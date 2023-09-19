using Infrastructure.Model.Implementations;

namespace BakeryApp.Model.DTOs.Category.Get
{
    public class CategoryGetDto : Dto<int>
    {
        public string Name { get; set; }
    }
}
