namespace api.Common
{
    public class AppException : Exception
    {
        public int StatusCode { get; }

        public AppException(int statusCode, string message) : base(message) {
            this.StatusCode = statusCode;
        }

    }
}
