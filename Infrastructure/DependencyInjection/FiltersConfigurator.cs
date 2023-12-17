using NotificationPatternSample.Presentation.Filters;

namespace NotificationPatternSample.Infrastructure.DependencyInjection
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
