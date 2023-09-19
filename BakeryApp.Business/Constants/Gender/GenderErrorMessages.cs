namespace BakeryApp.Business.Constants.Gender
{
    public static class GenderErrorMessages
    {
        public static string IdGreaterThanZero = "Cinsiyet Id değeri 0'dan büyük olmalıdır.";
        public static string NotFoundById = "Girilen Id'ye göre cinsiyet verisi bulunamadı.";

        public static string NameCannotBeEmpty = "Cinsiyet adı boş olamaz.";
        public static string NameMinumumLength = "Cinsiyet adı en az 2 karakter içermelidir.";
        public static string NameMaximumLength = "Cinsiyet adı en fazla 50 karakter içermelidir.";

        public static string NotFoundGenders = "Cinsiyetlere ait veri bulunamadı.";
    }
}
