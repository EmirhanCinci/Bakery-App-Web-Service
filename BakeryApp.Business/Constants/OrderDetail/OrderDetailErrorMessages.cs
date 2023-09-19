namespace BakeryApp.Business.Constants.OrderDetail
{
    public static class OrderDetailErrorMessages
    {
        public static string IdGreaterThanZero = "Sipariş detay Id değeri 0'dan büyük olmalıdır.";
        public static string NotFoundById = "Girilen Id'ye göre sipariş detay verisi bulunamadı.";

        public static string OrderIdCannotBeEmpty = "Lütfen bir kullanıcı giriniz.";
        public static string FoodIdCannotBeEmpty = "Lütfen bir yemek giriniz.";
        public static string UnitPriceGreaterThanZero = "Fiyat 0'dan büyük olmalıdır.";
        public static string QuantityGreaterThanZero = "Miktar 0'dan büyük olmalıdır.";

        public static string NotFoundOrders = "Sipariş detaylara ait veri bulunamadı.";
    }
}
