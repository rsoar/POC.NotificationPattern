using NotificationPatternSample.Domain.Entities;
using NotificationPatternSample.Domain.Interfaces;
using NotificationPatternSample.Shared.Notification;

namespace NotificationPatternSample.Domain.Validators
{
    public class CustomerValidator() : IValidator<Customer>
    {
        public void Validate(Customer model, NotificationContext notificationContext)
        {
            if (string.IsNullOrWhiteSpace(model.Name))
            {
                notificationContext.AddNotification(NotificationCode.NCustomerName, NotificationKey.NCustomerName, "The 'Name' field must be filled in.");
            }
        }
    }
}
