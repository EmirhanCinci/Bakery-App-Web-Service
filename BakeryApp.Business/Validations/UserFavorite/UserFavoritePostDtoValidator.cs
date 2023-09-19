using BakeryApp.Business.Constants.UserFavorite;
using BakeryApp.Model.DTOs.UserFavorite.Post;
using FluentValidation;

namespace BakeryApp.Business.Validations.UserFavorite
{
    public class UserFavoritePostDtoValidator : AbstractValidator<UserFavoritePostDto>
    {
        public UserFavoritePostDtoValidator() 
        {
            RuleFor(x => x.UserId).InclusiveBetween(1, int.MaxValue).WithMessage(UserFavoriteErrorMessages.UserIdCannotBeEmpty);

            RuleFor(x => x.FoodId).InclusiveBetween(1, int.MaxValue).WithMessage(UserFavoriteErrorMessages.FoodIdCannotBeEmpty);
        }
    }
}
