using Infrastructure.Model.Implementations;

namespace BakeryApp.Model.DTOs.FoodComment.Get
{
    public class FoodCommentGetDto : Dto<int>
    {
        public string UserFullName { get; set; }
        public string FoodName { get; set; }
        public string Text { get; set; }
        public string Photo { get; set; }
        public int Points { get; set; }
    }
}
