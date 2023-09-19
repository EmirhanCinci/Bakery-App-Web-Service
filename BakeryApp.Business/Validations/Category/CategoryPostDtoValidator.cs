using BakeryApp.Business.Constants.Category;
using BakeryApp.Model.DTOs.Category.Post;
using FluentValidation;

namespace BakeryApp.Business.Validations.Category
{
    public class CategoryPostDtoValidator : AbstractValidator<CategoryPostDto>
    {
        public CategoryPostDtoValidator() 
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(CategoryErrorMessages.NameCannotBeEmpty)
                .MinimumLength(2).WithMessage(CategoryErrorMessages.NameMinumumLength)
                .MaximumLength(50).WithMessage(CategoryErrorMessages.NameMaximumLength);
        }
    }
}
