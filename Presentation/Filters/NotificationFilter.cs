using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using NotificationPatternSample.Shared.Notification;

namespace NotificationPatternSample.Presentation.Filters
{
    public class NotificationFilter : IAsyncResultFilter
    {
        private readonly NotificationContext _notificationContext;
        private readonly ILogger<NotificationFilter> _logger;

        public NotificationFilter(NotificationContext notificationContext, ILogger<NotificationFilter> logger)
        {
            _notificationContext = notificationContext;
            _logger = logger;
        }

        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            if (_notificationContext.HasNotifications)
            {
                context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.HttpContext.Response.ContentType = "application/json";

                var notifications = JsonConvert.SerializeObject(_notificationContext.Notifications);
                await context.HttpContext.Response.WriteAsync(notifications);

                _logger.LogError(message: notifications);

                return;
            }

            await next();
        }
    }
}
