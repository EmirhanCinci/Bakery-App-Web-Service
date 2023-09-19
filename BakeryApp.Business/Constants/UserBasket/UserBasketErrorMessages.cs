namespace BakeryApp.Business.Constants.UserBasket
{
    public static class UserBasketErrorMessages
    {
        public static string IdGreaterThanZero = "Sepet Id değeri 0'dan büyük olmalıdır.";
        public static string NotFoundById = "Girilen Id'ye göre sepet verisi bulunamadı.";

        public static string UserIdCannotBeEmpty = "Lütfen bir kullanıcı seçiniz.";
        public static string FoodIdCannotBeEmpty = "Lütfen bir yemek seçiniz.";

        public static string NotFoundUserBaskets = "Sepetlere ait veri bulunamadı.";
    }
}
