using ExceptionHandlingDemo;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddExceptionHandler<CustomExceptionHandler>();

var app = builder.Build();
app.UseExceptionHandler(_ => { });

app.MapGet("/api/gettasks", () =>
{
    throw new InvalidProgramException("Something went wrong");
});

app.Run();