using BakeryApp.Business.Constants.User;
using BakeryApp.Model.DTOs.User.Put;
using FluentValidation;

namespace BakeryApp.Business.Validations.User
{
    public class UserPutDtoValidator : AbstractValidator<UserPutDto>
    {
        public UserPutDtoValidator() 
        {
            RuleFor(x => x.Id).InclusiveBetween(1, int.MaxValue).WithMessage(UserErrorMessages.IdGreaterThanZero);

            RuleFor(x => x.FirstName).NotEmpty().WithMessage(UserErrorMessages.FirstNameCannotBeEmpty)
                 .MinimumLength(2).WithMessage(UserErrorMessages.FirstNameMinumumLength)
                 .MaximumLength(50).WithMessage(UserErrorMessages.FirstNameMaximumLength);

            RuleFor(x => x.LastName).NotEmpty().WithMessage(UserErrorMessages.LastNameCannotBeEmpty)
                .MinimumLength(2).WithMessage(UserErrorMessages.LastNameMinumumLength)
                .MaximumLength(50).WithMessage(UserErrorMessages.LastNameMaximumLength);

            RuleFor(x => x.Email).NotEmpty().WithMessage(UserErrorMessages.EmailCannotBeEmpty)
                .EmailAddress().WithMessage(UserErrorMessages.EmailNotFormat);

            RuleFor(x => x.CityId).InclusiveBetween(1, int.MaxValue).WithMessage(UserErrorMessages.CityIdCannotBeEmpty);

            RuleFor(x => x.GenderId).InclusiveBetween(1, int.MaxValue).WithMessage(UserErrorMessages.GenderIdCannotBeEmpty);

            RuleFor(x => x.Password).NotEmpty().WithMessage(UserErrorMessages.PasswordCannotBeEmpty)
                .MinimumLength(8).WithMessage(UserErrorMessages.PasswordMinumumLength)
                .MaximumLength(25).WithMessage(UserErrorMessages.PasswordMaximumLength)
                .Must(ContainUppercase).WithMessage(UserErrorMessages.PasswordIsUpperCase)
                .Must(ContainLowercase).WithMessage(UserErrorMessages.PasswordIsLowerCase)
                .Must(ContainDigit).WithMessage(UserErrorMessages.PasswordIsDigit)
                .Must(ContainSpecialCharacter).WithMessage(UserErrorMessages.PasswordIsSpecial);
        }
        private bool ContainUppercase(string password)
        {
            return password.Any(char.IsUpper);
        }

        private bool ContainLowercase(string password)
        {
            return password.Any(char.IsLower);
        }

        private bool ContainDigit(string password)
        {
            return password.Any(char.IsDigit);
        }

        private bool ContainSpecialCharacter(string password)
        {
            return password.Any(ch => !char.IsLetterOrDigit(ch));
        }
    }
}
