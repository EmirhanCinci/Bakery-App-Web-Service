using BakeryApp.Business.Constants.Food;
using BakeryApp.Business.Constants.FoodComment;
using BakeryApp.Model.DTOs.FoodComment.Put;
using FluentValidation;

namespace BakeryApp.Business.Validations.FoodComment
{
    public class FoodCommentPutDtoValidator : AbstractValidator<FoodCommentPutDto>
    {
        public FoodCommentPutDtoValidator() 
        {
            RuleFor(x => x.Id).InclusiveBetween(1, int.MaxValue).WithMessage(FoodErrorMessages.IdGreaterThanZero);

            RuleFor(x => x.UserId).InclusiveBetween(1, int.MaxValue).WithMessage(FoodCommentErrorMessages.UserIdCannotBeEmpty);

            RuleFor(x => x.FoodId).InclusiveBetween(1, int.MaxValue).WithMessage(FoodCommentErrorMessages.FoodIdCannotBeEmpty);

            RuleFor(x => x.Text).MaximumLength(250).WithMessage(FoodCommentErrorMessages.TextMaximumLength);

            RuleFor(x => x.Points).NotEmpty().WithMessage(FoodCommentErrorMessages.PointsCannotBeEmpty)
                .InclusiveBetween(1, 5).WithMessage(FoodCommentErrorMessages.PointsRange);
        }
    }
}
