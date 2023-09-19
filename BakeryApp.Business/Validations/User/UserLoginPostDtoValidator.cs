using BakeryApp.Business.Constants.User;
using BakeryApp.Model.DTOs.User.Post;
using FluentValidation;

namespace BakeryApp.Business.Validations.User
{
    public class UserLoginPostDtoValidator : AbstractValidator<UserLoginPostDto>
    {
        public UserLoginPostDtoValidator() 
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage(UserErrorMessages.EmailCannotBeEmpty)
                .EmailAddress().WithMessage(UserErrorMessages.EmailNotFormat);
        }
    }
}
