namespace BakeryApp.Business.Constants.Category
{
    public static class CategoryErrorMessages
    {
        public static string IdGreaterThanZero = "Kategori Id değeri 0'dan büyük olmalıdır.";
        public static string NotFoundById = "Girilen Id'ye göre kategori verisi bulunamadı.";

        public static string NameCannotBeEmpty = "Kategori adı boş olamaz.";
        public static string NameMinumumLength = "Kategori adı en az 2 karakter içermelidir.";
        public static string NameMaximumLength = "Kategori adı en fazla 50 karakter içermelidir.";

        public static string NameExists = "Bu isimle kayıtlı bir kategori mevcuttur.";

        public static string NotFoundCategories = "Kategorilere ait veri bulunamadı.";
    }
}
