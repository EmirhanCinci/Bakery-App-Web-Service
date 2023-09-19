using BakeryApp.Business.Constants.Country;
using BakeryApp.Model.DTOs.Country.Post;
using FluentValidation;

namespace BakeryApp.Business.Validations.Country
{
    public class CountryPostDtoValidator : AbstractValidator<CountryPostDto>
    {
        public CountryPostDtoValidator() 
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(CountryErrorMessages.NameCannotBeEmpty)
                .MinimumLength(2).WithMessage(CountryErrorMessages.NameMinumumLength)
                .MaximumLength(50).WithMessage(CountryErrorMessages.NameMaximumLength);
        }
    }
}
