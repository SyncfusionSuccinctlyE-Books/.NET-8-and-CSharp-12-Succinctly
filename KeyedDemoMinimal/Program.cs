using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddKeyedSingleton<IGreeter, FormalGreeterService>("customers");
builder.Services.AddKeyedSingleton<IGreeter, InformalGreeterService>("friends");
builder.Services.AddSingleton<CustomerService>();
builder.Services.AddSingleton<FriendsService>();

builder.Services.AddKeyedSingleton<IGreeter, FormalGreeterService>("ceo");
builder.Services.AddKeyedSingleton<IGreeter, FormalGreeterService>("cto");



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("api/GreetCustomer", (CustomerService customer) => customer.Greet());

app.MapGet("api/GreetFriend", (FriendsService friend) => friend.Greet());

app.MapGet("api/GreetFriendSpecific", 
    ([FromKeyedServices("friends")] IGreeter greet, string friendName) => 
    greet.Greeting($"Hey {friendName}. Nice to see you."));

app.MapGet("api/GreetCustomerSpecific", 
    (HttpContext httpContext, string customerName) => 
    httpContext.RequestServices
    .GetRequiredKeyedService<IGreeter>("customers")
    .Greeting($"Good day {customerName}. How many I assist you?"));

app.MapGet("api/GreetCEO",
    ([FromKeyedServices("ceo")] IGreeter greet) =>
    greet.Greeting($"Good day Mr CEO. How many I assist you?"));

app.MapGet("api/GreetCTO",
    ([FromKeyedServices("cto")] IGreeter greet) =>
    greet.Greeting($"Good day Mr CTO. How many I assist you?"));


app.Run();

public class CustomerService([FromKeyedServices("customers")] IGreeter greeter)
{
    public string Greet() => greeter.Greeting("Good day, can I be of service?");
}

public class FriendsService(IServiceProvider serviceProvider)
{
    public string Greet() => serviceProvider.GetRequiredKeyedService<IGreeter>("friends").Greeting("Hello buddy!");
}



public interface IGreeter
{
    string Greeting(string message);
}

public class FormalGreeterService : IGreeter
{
    public string Greeting(string message) => $"Formal greeting: {message}";
}

public class InformalGreeterService : IGreeter
{
    public string Greeting(string message) => $"Informal greeting: {message}";
}

public class FlexibleGreeterService(string name) : IGreeter
{
    public string Greeting(string message) => $"Flexible greeting: {message}";
}
