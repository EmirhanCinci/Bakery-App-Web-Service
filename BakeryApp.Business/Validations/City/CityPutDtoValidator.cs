using BakeryApp.Business.Constants.City;
using BakeryApp.Model.DTOs.City.Put;
using FluentValidation;

namespace BakeryApp.Business.Validations.City
{
    public class CityPutDtoValidator : AbstractValidator<CityPutDto>
    {
        public CityPutDtoValidator() 
        {
            RuleFor(x => x.Id).InclusiveBetween(1, int.MaxValue).WithMessage(CityErrorMessages.IdGreaterThanZero);

            RuleFor(x => x.Name).NotEmpty().WithMessage(CityErrorMessages.NameCannotBeEmpty)
                .MinimumLength(2).WithMessage(CityErrorMessages.NameMinumumLength)
                .MaximumLength(50).WithMessage(CityErrorMessages.NameMaximumLength);

            RuleFor(x => x.CountryId).InclusiveBetween(1, int.MaxValue).WithMessage(CityErrorMessages.CountryIdCannotBeEmpty);
        }
    }
}
