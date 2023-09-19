namespace BakeryApp.Business.Constants.Order
{
    public static class OrderErrorMessages
    {
        public static string IdGreaterThanZero = "Sipariş Id değeri 0'dan büyük olmalıdır.";
        public static string NotFoundById = "Girilen Id'ye göre sipariş verisi bulunamadı.";

        public static string UserIdCannotBeEmpty = "Lütfen bir kullanıcı giriniz.";
        public static string PriceGreaterThanZero = "Fiyat 0'dan büyük olmalıdır.";

        public static string NotFoundOrders = "Siparişlere ait veri bulunamadı.";
    }
}
