using BakeryApp.Business.Constants.Category;
using BakeryApp.Model.DTOs.Category.Put;
using FluentValidation;

namespace BakeryApp.Business.Validations.Category
{
    public class CategoryPutDtoValidator : AbstractValidator<CategoryPutDto>
    {
        public CategoryPutDtoValidator() 
        {
            RuleFor(x => x.Id).InclusiveBetween(1, int.MaxValue).WithMessage(CategoryErrorMessages.IdGreaterThanZero);

            RuleFor(x => x.Name).NotEmpty().WithMessage(CategoryErrorMessages.NameCannotBeEmpty)
                .MinimumLength(2).WithMessage(CategoryErrorMessages.NameMinumumLength)
                .MaximumLength(50).WithMessage(CategoryErrorMessages.NameMaximumLength);
        }
    }
}
