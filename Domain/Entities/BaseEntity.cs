using NotificationPatternSample.Domain.Interfaces;
using NotificationPatternSample.Shared.Notification;

namespace NotificationPatternSample.Domain.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public bool Valid { get; private set; }
        public bool Invalid => !Valid;
        public NotificationContext NotificationContext { get; private set; }

        public bool Validate<TModel>(TModel model, IValidator<TModel> validator)
        {
            NotificationContext = new NotificationContext();
            validator.Validate(model, NotificationContext);
            Valid = !NotificationContext.HasNotifications;

            return Valid;
        }
    }
}
