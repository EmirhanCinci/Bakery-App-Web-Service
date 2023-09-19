using BakeryApp.Business.Constants.UserBasket;
using BakeryApp.Model.DTOs.UserBasket.Post;
using FluentValidation;

namespace BakeryApp.Business.Validations.UserBasket
{
    public class UserBasketPostDtoValidator : AbstractValidator<UserBasketPostDto>
    {
        public UserBasketPostDtoValidator()
        {
            RuleFor(x => x.UserId).InclusiveBetween(1, int.MaxValue).WithMessage(UserBasketErrorMessages.UserIdCannotBeEmpty);

            RuleFor(x => x.FoodId).InclusiveBetween(1, int.MaxValue).WithMessage(UserBasketErrorMessages.FoodIdCannotBeEmpty);
        }
    }
}
