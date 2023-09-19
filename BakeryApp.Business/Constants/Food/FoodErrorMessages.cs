namespace BakeryApp.Business.Constants.Food
{
    public static class FoodErrorMessages
    {
        public static string IdGreaterThanZero = "Yemek Id değeri 0'dan büyük olmalıdır.";
        public static string NotFoundById = "Girilen Id'ye göre yemek verisi bulunamadı.";

        public static string NameCannotBeEmpty = "Yemek adı boş olamaz.";
        public static string NameMinumumLength = "Yemek adı en az 2 karakter içermelidir.";
        public static string NameMaximumLength = "Yemek adı en fazla 50 karakter içermelidir.";

        public static string UnitPriceCannotBeEmpty = "Fiyat alanı boş bırakılamaz.";
        public static string UnitPriceGreaterThanZero = "Girilen fiyat değeri 0'dan büyük olmalıdır.";

        public static string DescriptionCannotBeEmpty = "Açıklama alanı boş bırakılamaz.";
        public static string DescriptionMinumumLength = "Açıklama alanı en az 5 karakterden oluşmalıdır.";
        public static string DescriptionMaximumLength = "Açıklama alanı en fazla 500 karakterden oluşmalıdır.";

        public static string CategoryIdCannotBeEmpty = "Lütfen bir kategori seçiniz.";

        public static string NotFoundFoods = "Yemeklere ait veri bulunamadı.";
    }
}
