using NotificationPatternSample.Shared.Notification;

namespace NotificationPatternSample.Domain.Interfaces
{
    public interface IValidator<TModel>
    {
        void Validate(TModel model, NotificationContext notificationContext);
    }
}
