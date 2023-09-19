using BakeryApp.Business.Constants.FoodMaterial;
using BakeryApp.Model.DTOs.FoodMaterial.Post;
using FluentValidation;

namespace BakeryApp.Business.Validations.FoodMaterial
{
    public class FoodMaterialPostDtoValidator : AbstractValidator<FoodMaterialPostDto>
    {
        public FoodMaterialPostDtoValidator() 
        {
            RuleFor(x => x.FoodId).InclusiveBetween(1, int.MaxValue).WithMessage(FoodMaterialErrorMessages.FoodIdCannotBeEmpty);

            RuleFor(x => x.Material).NotEmpty().WithMessage(FoodMaterialErrorMessages.MaterialCannotBeEmpty)
                .MinimumLength(2).WithMessage(FoodMaterialErrorMessages.MaterialMinumumLength)
                .MaximumLength(100).WithMessage(FoodMaterialErrorMessages.MaterialMaximumLength);
        }
    }
}
