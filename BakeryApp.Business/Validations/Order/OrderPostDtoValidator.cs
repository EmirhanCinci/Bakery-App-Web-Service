using BakeryApp.Business.Constants.Order;
using BakeryApp.Model.DTOs.Order.Post;
using FluentValidation;

namespace BakeryApp.Business.Validations.Order
{
    public class OrderPostDtoValidator : AbstractValidator<OrderPostDto>
    {
        public OrderPostDtoValidator() 
        {
            RuleFor(x => x.UserId).InclusiveBetween(1, int.MaxValue).WithMessage(OrderErrorMessages.UserIdCannotBeEmpty);

            RuleFor(x => x.Price).GreaterThan(0).WithMessage(OrderErrorMessages.PriceGreaterThanZero);
        }
    }
}
