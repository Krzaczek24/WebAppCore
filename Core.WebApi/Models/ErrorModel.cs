namespace Core.WebApi.Models
{
    public class ErrorModel
    {
        public int Code { get; } = 1;
        public string Message { get; } = "An unexpected error occurred!";

        public ErrorModel() { }

        public ErrorModel(string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                Message = message;
            }
        }

        public ErrorModel(int code, string message) : this(message)
        {
            Code = code;
        }
    }
}
