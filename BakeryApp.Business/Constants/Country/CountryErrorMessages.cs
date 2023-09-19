namespace BakeryApp.Business.Constants.Country
{
    public static class CountryErrorMessages
    {
        public static string IdGreaterThanZero = "Ülke Id değeri 0'dan büyük olmalıdır.";
        public static string NotFoundById = "Girilen Id'ye göre ülke verisi bulunamadı.";

        public static string NameCannotBeEmpty = "Ülke adı boş olamaz.";
        public static string NameMinumumLength = "Ülke adı en az 2 karakter içermelidir.";
        public static string NameMaximumLength = "Ülke adı en fazla 50 karakter içermelidir.";

        public static string NameExists = "Bu isimle kayıtlı bir ülke mevcuttur.";

        public static string NotFoundCountries = "Ülkelere ait veri bulunamadı.";
    }
}
