using Infrastructure.Model.Interfaces;

namespace BakeryApp.Model.DTOs.FoodComment.Post
{
    public class FoodCommentPostDto : IDto
    {
        public int UserId { get; set; }
        public int FoodId { get; set; }
        public string Text { get; set; }
        public string Photo { get; set; }
        public int Points { get; set; }
    }
}
