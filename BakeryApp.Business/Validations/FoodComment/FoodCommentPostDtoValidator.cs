using BakeryApp.Business.Constants.FoodComment;
using BakeryApp.Model.DTOs.FoodComment.Post;
using FluentValidation;

namespace BakeryApp.Business.Validations.FoodComment
{
    public class FoodCommentPostDtoValidator : AbstractValidator<FoodCommentPostDto>
    {
        public FoodCommentPostDtoValidator() 
        {
            RuleFor(x => x.UserId).InclusiveBetween(1, int.MaxValue).WithMessage(FoodCommentErrorMessages.UserIdCannotBeEmpty);

            RuleFor(x => x.FoodId).InclusiveBetween(1, int.MaxValue).WithMessage(FoodCommentErrorMessages.FoodIdCannotBeEmpty);

            RuleFor(x => x.Text).MaximumLength(250).WithMessage(FoodCommentErrorMessages.TextMaximumLength);

            RuleFor(x => x.Points).NotEmpty().WithMessage(FoodCommentErrorMessages.PointsCannotBeEmpty)
                .InclusiveBetween(1, 5).WithMessage(FoodCommentErrorMessages.PointsRange);
        }
    }
}
