using BakeryApp.Business.Constants.FoodPhoto;
using BakeryApp.Model.DTOs.Food.Post;
using BakeryApp.Model.DTOs.FoodPhoto.Post;
using FluentValidation;

namespace BakeryApp.Business.Validations.FoodPhoto
{
    public class FoodPhotoPostDtoValidator : AbstractValidator<FoodPhotoPostDto>
    {
        public FoodPhotoPostDtoValidator()
        {
            RuleFor(x => x.FoodId).InclusiveBetween(1, int.MaxValue).WithMessage(FoodPhotoErrorMessages.FoodIdCannotBeEmpty);
        }
    }
}
