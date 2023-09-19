using BakeryApp.Business.Constants.Country;
using BakeryApp.Model.DTOs.Country.Put;
using FluentValidation;

namespace BakeryApp.Business.Validations.Country
{
    public class CountryPutDtoValidator : AbstractValidator<CountryPutDto>
    {
        public CountryPutDtoValidator()
        {
            RuleFor(x => x.Id).InclusiveBetween(1, int.MaxValue).WithMessage(CountryErrorMessages.IdGreaterThanZero);

            RuleFor(x => x.Name).NotEmpty().WithMessage(CountryErrorMessages.NameCannotBeEmpty)
                .MinimumLength(2).WithMessage(CountryErrorMessages.NameMinumumLength)
                .MaximumLength(50).WithMessage(CountryErrorMessages.NameMaximumLength);
        }
    }
}
