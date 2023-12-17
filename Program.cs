using NotificationPatternSample.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddServices();
builder.Services.AddControllers();
builder.AddHttpFilters();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseGlobalExceptionHandler(app.Environment, app.Services.GetRequiredService<ILoggerFactory>());

if(app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
