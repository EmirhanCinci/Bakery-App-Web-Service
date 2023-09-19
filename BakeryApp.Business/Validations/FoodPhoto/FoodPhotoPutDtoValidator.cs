using BakeryApp.Business.Constants.FoodPhoto;
using BakeryApp.Model.DTOs.FoodPhoto.Put;
using FluentValidation;

namespace BakeryApp.Business.Validations.FoodPhoto
{
    public class FoodPhotoPutDtoValidator : AbstractValidator<FoodPhotoPutDto>
    {
        public FoodPhotoPutDtoValidator()
        {
            RuleFor(x => x.Id).InclusiveBetween(1, int.MaxValue).WithMessage(FoodPhotoErrorMessages.IdGreaterThanZero);

            RuleFor(x => x.FoodId).InclusiveBetween(1, int.MaxValue).WithMessage(FoodPhotoErrorMessages.FoodIdCannotBeEmpty);
        }
    }
}
