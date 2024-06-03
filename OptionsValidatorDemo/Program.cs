using System.Text.Json;
using Microsoft.Extensions.Options;
using OptionsValidatorDemo;

var builder = WebApplication.CreateBuilder(args);
var cfg = builder.Configuration;
// Add services to the container.

builder.Services
    .Configure<ApiConfigOptions>(cfg.GetSection(ApiConfigOptions.SectionName));

builder.Services
    .AddSingleton<IValidateOptions<ApiConfigOptions>, ApiConfigOptionsValidator>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var settingOptions = app.Services.GetRequiredService<IOptions<ApiConfigOptions>>().Value;


app.MapGet("api/sendnotification", () =>
{
    var notificationType = settingOptions.NotificationType;
    return Enum.TryParse<NotificationType>(notificationType, out var type)
        ? type switch
        {
            NotificationType.Email => "Sending email notification",
            NotificationType.Sms => "Sending sms notification",
            NotificationType.Push => "Sending push notification",
            _ => "Invalid notification type",
        }
        : "Notification not sent due to undefined notification type";
})
.WithName("SendNotification")
.WithDescription("Send notification to the user")
.WithOpenApi();



//app.MapGet("api/sendnotification", (IOptions<ApiConfigOptions> opt) =>
//{
//    var notificationType = opt.Value.NotificationType;
//    return Enum.TryParse<NotificationType>(notificationType, out var type)
//        ? type switch
//        {
//            NotificationType.Email => "Sending email notification",
//            NotificationType.Sms => "Sending sms notification",
//            NotificationType.Push => "Sending push notification",
//            _ => "Invalid notification type",
//        }
//        : "Notification not sent due to undefined notification type";
//})
//.WithName("SendNotification")
//.WithDescription("Send notification to the user")
//.WithOpenApi();



//// Validate Settings
//app.MapGet("api/validatesettings", (IOptions<ApiConfigOptions> opt) =>
//{
//    var options = new JsonSerializerOptions { WriteIndented = true };

//    try
//    {
//        return JsonSerializer.Serialize(new { status = "OK", settings = opt.Value }, options);
//    }
//    catch (Exception ex)
//    {
//        return JsonSerializer.Serialize(new { status = "ERROR", error = ex.Message }, options);
//    }
//})
//.WithName("ValidateSettings")
//.WithDescription("Perform a Health Check On The App Settings")
//.WithOpenApi();



app.Run();

