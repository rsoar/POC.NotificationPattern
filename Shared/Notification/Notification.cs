namespace NotificationPatternSample.Shared.Notification
{
    public class Notification
    {
        public Notification(NotificationCode code, string key, string message)
        {
            Code = code;
            Key = key;
            Message = message;
        }

        public NotificationCode Code { get; set; }
        public string Key { get; }
        public string Message { get; }
    }
}
