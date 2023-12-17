using NotificationPatternSample.Application.Interfaces;
using NotificationPatternSample.Domain.Entities;
using NotificationPatternSample.Presentation.DTOs.Request;
using NotificationPatternSample.Shared.Notification;

namespace NotificationPatternSample.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly NotificationContext _notificationContext;
        public CustomerService(NotificationContext notificationContext)
        {
            _notificationContext = notificationContext;
        }

        public void Create(CreateCustomerRequest data)
        {
            Customer customer = new(data.Name);

            if (customer.Invalid)
            {
                _notificationContext.AddNotifications(customer.NotificationContext);
                return;
            }

            Console.WriteLine("Customer created successfully!");
        }
    }
}
