namespace NotificationPatternSample.Shared.Http
{
    public class ApiErrorResult
    {
        public int StatusCode { get; set; }
        public List<object> Messages { get; set; } = [];
        public string Details { get; set; } = "";
    }
}
