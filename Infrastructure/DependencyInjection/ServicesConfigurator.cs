using NotificationPatternSample.Application.Interfaces;
using NotificationPatternSample.Application.Services;
using NotificationPatternSample.Shared.Notification;

namespace NotificationPatternSample.Infrastructure.DependencyInjection
{
    public static class ServicesConfigurator
    {
        public static WebApplicationBuilder AddServices(this WebApplicationBuilder builder)
        {
            builder.Services
                .AddScoped<NotificationContext>()
                .AddScoped<ICustomerService, CustomerService>();

            return builder;
        }
    }
}
