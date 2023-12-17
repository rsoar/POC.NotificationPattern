using Microsoft.AspNetCore.Diagnostics;
using Newtonsoft.Json;
using NotificationPatternSample.Shared.Http;

namespace NotificationPatternSample.Infrastructure.Extensions
{
    public static class ExceptionHandler
    {
        public static void UseGlobalExceptionHandler(this IApplicationBuilder app, IWebHostEnvironment environment, ILoggerFactory loggerFactory)
        {
            app.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                {
                    var excHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (excHandlerFeature != null)
                    {
                        ILogger logger = loggerFactory.CreateLogger("GlobalExceptionHandler");

                        context.Response.ContentType = "application/json";

                        ApiErrorResult result = new();

                        if (excHandlerFeature.Error is GenericCustomException exc)
                        {
                            result.StatusCode = exc.StatusCode;
                            result.Messages.Add(exc.Message);

                            if (environment.IsDevelopment())
                            {
                                result.Details = exc.ToString();
                            }

                            logger.LogError($"Error: {exc.StatusCode}");
                        }
                        else
                        {
                            result.StatusCode = StatusCodes.Status500InternalServerError;
                            result.Messages.Add("An error occurred whilst processing your request");
                            logger.LogError($"Unexpected error: {excHandlerFeature.Error}");

                            if (environment.IsDevelopment())
                            {
                                result.Details = excHandlerFeature.Error.ToString();
                            }
                        }

                        await context.Response.WriteAsync(JsonConvert.SerializeObject(result));
                    }
                });
            });
        }
    }
}
