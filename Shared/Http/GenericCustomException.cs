namespace NotificationPatternSample.Shared.Http
{
    public class GenericCustomException : Exception
    {
        public GenericCustomException(int statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }

        public int StatusCode { get; }
        public override string Message { get; }
    }
}
