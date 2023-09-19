using Infrastructure.Model.Interfaces;

namespace BakeryApp.Model.DTOs.FoodComment.Get
{
    public class FoodCommentTextGetDto : IDto
    {
        public int Id { get; set; }
        public string UserFullName { get; set; }
        public string Text { get; set; }
        public string Photo { get; set; }
        public int Points { get; set; }
    }
}
