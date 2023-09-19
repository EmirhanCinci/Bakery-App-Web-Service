using BakeryApp.Business.Constants.Food;
using BakeryApp.Model.DTOs.Food.Post;
using FluentValidation;

namespace BakeryApp.Business.Validations.Food
{
    public class FoodPostDtoValidator : AbstractValidator<FoodPostDto>
    {
        public FoodPostDtoValidator() 
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(FoodErrorMessages.NameCannotBeEmpty)
                .MinimumLength(2).WithMessage(FoodErrorMessages.NameMinumumLength)
                .MaximumLength(50).WithMessage(FoodErrorMessages.NameMaximumLength);

            RuleFor(x => x.UnitPrice).NotEmpty().WithMessage(FoodErrorMessages.UnitPriceCannotBeEmpty)
                .GreaterThan(0).WithMessage(FoodErrorMessages.UnitPriceGreaterThanZero);

            RuleFor(x => x.Description).NotEmpty().WithMessage(FoodErrorMessages.DescriptionCannotBeEmpty)
                .MinimumLength(5).WithMessage(FoodErrorMessages.DescriptionMinumumLength)
                .MaximumLength(500).WithMessage(FoodErrorMessages.DescriptionMaximumLength);

            RuleFor(x => x.CategoryId).InclusiveBetween(1, int.MaxValue).WithMessage(FoodErrorMessages.CategoryIdCannotBeEmpty);
        }
    }
}
