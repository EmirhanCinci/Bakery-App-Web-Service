using BakeryApp.Model.DTOs.FoodComment.Get;
using BakeryApp.Model.DTOs.FoodMaterial.Get;
using BakeryApp.Model.DTOs.FoodPhoto.Get;
using Infrastructure.Model.Implementations;

namespace BakeryApp.Model.DTOs.Food.Get
{
    public class SingleFoodGetDto : Dto<int>
    {
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public bool IsStock { get; set; }

        public virtual ICollection<FoodMaterialNameGetDto> FoodMaterials { get; set; }
        public virtual ICollection<FoodCommentTextGetDto> FoodComments { get; set; }
        public virtual ICollection<FoodPhotoSingleGetDto> FoodPhotos { get; set; }
    }
}
