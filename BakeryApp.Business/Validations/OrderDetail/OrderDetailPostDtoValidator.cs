using BakeryApp.Business.Constants.OrderDetail;
using BakeryApp.Model.DTOs.OrderDetail.Post;
using FluentValidation;

namespace BakeryApp.Business.Validations.OrderDetail
{
    public class OrderDetailPostDtoValidator : AbstractValidator<OrderDetailPostDto>
    {
        public OrderDetailPostDtoValidator()
        {
            RuleFor(x => x.OrderId).InclusiveBetween(1, int.MaxValue).WithMessage(OrderDetailErrorMessages.OrderIdCannotBeEmpty);

            RuleFor(x => x.FoodId).InclusiveBetween(1, int.MaxValue).WithMessage(OrderDetailErrorMessages.FoodIdCannotBeEmpty);

            RuleFor(x => x.UnitPrice).GreaterThan(0).WithMessage(OrderDetailErrorMessages.UnitPriceGreaterThanZero);

            RuleFor(x => x.Quantity).GreaterThan(0).WithMessage(OrderDetailErrorMessages.QuantityGreaterThanZero);
        }
    }
}
