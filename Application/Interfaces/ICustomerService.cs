using NotificationPatternSample.Presentation.DTOs.Request;

namespace NotificationPatternSample.Application.Interfaces
{
    public interface ICustomerService
    {
        public void Create(CreateCustomerRequest entry);
    }
}
