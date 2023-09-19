namespace BakeryApp.Business.Constants.User
{
    public static class UserErrorMessages
    {
        public static string IdGreaterThanZero = "Kullanıcı Id değeri 0'dan büyük olmalıdır.";
        public static string NotFoundById = "Girilen Id'ye göre kullanıcı verisi bulunamadı.";

        public static string FirstNameCannotBeEmpty = "Kullanıcı adı boş olamaz.";
        public static string FirstNameMinumumLength = "Kullanıcı adı en az 2 karakter içermelidir.";
        public static string FirstNameMaximumLength = "Kullanıcı adı en fazla 50 karakter içermelidir.";

        public static string LastNameCannotBeEmpty = "Kullanıcı soyadı boş olamaz.";
        public static string LastNameMinumumLength = "Kullanıcı soyadı en az 2 karakter içermelidir.";
        public static string LastNameMaximumLength = "Kullanıcı soyadı en fazla 50 karakter içermelidir.";

        public static string EmailCannotBeEmpty = "Email alanı boş olamaz.";
        public static string EmailNotFormat = "Email alanı istenilen formata uygun değil.";

        public static string EmailNotFound = "Girilen email adresine göre bir kayıt yok.";

        public static string CityIdCannotBeEmpty = "Lütfen bir şehir seçiniz.";
        public static string GenderIdCannotBeEmpty = "Lütfen bir cinsiyet seçiniz.";

        public static string WrongPassword = "Şifre yanlış. Lütfen tekrar deneyiniz.";

        public static string PasswordCannotBeEmpty = "Şifre alanı boş bırakılamaz.";
        public static string PasswordMinumumLength = "Şifre alanı en az 8 karakterden oluşmalıdır.";
        public static string PasswordMaximumLength = "Şifre alanı en fazla 25 karakterden oluşmalıdır.";
        public static string PasswordIsUpperCase = "Şifre en az bir büyük harf içermelidir.";
        public static string PasswordIsLowerCase = "Şifre en az bir küçük harf içermelidir.";
        public static string PasswordIsDigit = "Şifre en az bir rakam içermelidir.";
        public static string PasswordIsSpecial = "Şifre en az bir özel karakter içermelidir.";

        public static string NotFoundUsers = "Kullanıcılara ait veri bulunamadı.";
    }
}
