namespace Infrastructure.Utilities.ApiResponses
{
    public class CustomResponse<T>
    {
        public T? Data { get; set; }
        public int StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public List<string> ErrorMessages { get; set; }

        public static CustomResponse<T> Success(int statusCode)
        {
            return new CustomResponse<T> { StatusCode = statusCode, StatusMessage = "İşlem başarılı." };
        }

        public static CustomResponse<T> Success(int statusCode, T data)
        {
            return new CustomResponse<T> { StatusCode = statusCode, StatusMessage = "İşlem başarılı.", Data = data };
        }

        public static CustomResponse<T> Fail(int statusCode, string errorMessage)
        {
            return new CustomResponse<T> { StatusCode = statusCode, StatusMessage = "İşlem başarısız.", ErrorMessages = new List<string> { errorMessage } };
        }

        public static CustomResponse<T> Fail(int statusCode, List<string> errorMessages)
        {
            return new CustomResponse<T> { StatusCode = statusCode, StatusMessage = "İşlem Başarısız.", ErrorMessages = errorMessages };
        }
    }
}
