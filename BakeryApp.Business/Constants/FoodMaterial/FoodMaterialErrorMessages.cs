namespace BakeryApp.Business.Constants.FoodMaterial
{
    public static class FoodMaterialErrorMessages
    {
        public static string IdGreaterThanZero = "Yemek malzeme Id değeri 0'dan büyük olmalıdır.";
        public static string NotFoundById = "Girilen Id'ye göre yemek malzeme verisi bulunamadı.";

        public static string MaterialCannotBeEmpty = "Yemek malzeme adı boş olamaz.";
        public static string MaterialMinumumLength = "Yemek malzeme adı en az 2 karakter içermelidir.";
        public static string MaterialMaximumLength = "Yemek malzeme adı en fazla 100 karakter içermelidir.";

        public static string FoodIdCannotBeEmpty = "Lütfen bir yemek seçiniz.";

        public static string NotFoundFoodMaterials = "Yemek malzemelerine ait veri bulunamadı.";
    }
}
