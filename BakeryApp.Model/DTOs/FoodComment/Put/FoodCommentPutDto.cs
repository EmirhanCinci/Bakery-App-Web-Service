using Infrastructure.Model.Interfaces;

namespace BakeryApp.Model.DTOs.FoodComment.Put
{
    public class FoodCommentPutDto : IDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int FoodId { get; set; }
        public string Text { get; set; }
        public string Photo { get; set; }
        public int Points { get; set; }
    }
}
