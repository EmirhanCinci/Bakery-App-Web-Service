namespace BakeryApp.Business.Constants.City
{
    public static class CityErrorMessages
    {
        public static string IdGreaterThanZero = "Şehir Id değeri 0'dan büyük olmalıdır.";
        public static string NotFoundById = "Girilen Id'ye göre şehir verisi bulunamadı.";

        public static string NameCannotBeEmpty = "Şehir adı boş olamaz.";
        public static string NameMinumumLength = "Şehir adı en az 2 karakter içermelidir.";
        public static string NameMaximumLength = "Şehir adı en fazla 50 karakter içermelidir.";

        public static string CountryIdCannotBeEmpty = "Lütfen bir ülke seçiniz.";

        public static string NotFoundCities = "Şehirlere ait veri bulunamadı.";

        public static string NameExists = "Bu isimle ve ülke ile kayıtlı bir şehir mevcuttur.";
    }
}
