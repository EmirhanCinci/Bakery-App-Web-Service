using BakeryApp.Business.Constants.FoodMaterial;
using BakeryApp.Model.DTOs.FoodMaterial.Put;
using FluentValidation;

namespace BakeryApp.Business.Validations.FoodMaterial
{
    public class FoodMaterialPutDtoValidator : AbstractValidator<FoodMaterialPutDto>
    {
        public FoodMaterialPutDtoValidator()
        {
            RuleFor(x => x.Id).InclusiveBetween(1, int.MaxValue).WithMessage(FoodMaterialErrorMessages.IdGreaterThanZero);

            RuleFor(x => x.FoodId).InclusiveBetween(1, int.MaxValue).WithMessage(FoodMaterialErrorMessages.FoodIdCannotBeEmpty);

            RuleFor(x => x.Material).NotEmpty().WithMessage(FoodMaterialErrorMessages.MaterialCannotBeEmpty)
                .MinimumLength(2).WithMessage(FoodMaterialErrorMessages.MaterialMinumumLength)
                .MaximumLength(100).WithMessage(FoodMaterialErrorMessages.MaterialMaximumLength);
        }
    }
}
