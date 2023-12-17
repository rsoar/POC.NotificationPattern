using NotificationPatternSample.Infrastructure.Filters;

namespace NotificationPatternSample.Infrastructure.Extensions
{
    public static class FiltersConfigurator
    {
        public static WebApplicationBuilder AddHttpFilters(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers(options => options.Filters.Add<NotificationFilter>());

            return builder;
        }
    }
}
