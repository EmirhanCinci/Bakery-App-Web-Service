namespace BakeryApp.Business.Constants.FoodComment
{
    public static class FoodCommentErrorMessages
    {
        public static string IdGreaterThanZero = "Yorum Id değeri 0'dan büyük olmalıdır.";
        public static string NotFoundById = "Girilen Id'ye göre yorum verisi bulunamadı.";

        public static string TextMaximumLength = "Yorumunuz en fazla 250 karakterden oluşmalıdır.";

        public static string UserIdCannotBeEmpty = "Lütfen bir kullanıcı seçiniz.";
        public static string FoodIdCannotBeEmpty = "Lütfen bir yemek seçiniz.";

        public static string PointsCannotBeEmpty = "Puanlama boş geçilemez.";
        public static string PointsRange = "Puanlama 1 ile 5 arasında olmalıdır.";

        public static string NotFoundComments = "Yorumlara ait veri bulunamadı.";
    }
}
