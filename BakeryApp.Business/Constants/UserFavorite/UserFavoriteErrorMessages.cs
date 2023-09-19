namespace BakeryApp.Business.Constants.UserFavorite
{
    public static class UserFavoriteErrorMessages
    {
        public static string IdGreaterThanZero = "Favori Id değeri 0'dan büyük olmalıdır.";
        public static string NotFoundById = "Girilen Id'ye göre favori verisi bulunamadı.";

        public static string UserIdCannotBeEmpty = "Lütfen bir kullanıcı seçiniz.";
        public static string FoodIdCannotBeEmpty = "Lütfen bir yemek seçiniz.";

        public static string NotFoundUserFavorites = "Favorilere ait veri bulunamadı.";
    }
}
