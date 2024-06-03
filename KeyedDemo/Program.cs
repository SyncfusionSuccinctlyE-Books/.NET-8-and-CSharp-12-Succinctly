
using KeyedDemo.Interfaces;
using KeyedDemo.Services;

namespace KeyedDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddKeyedSingleton<IGreeter, FormalGreeterService>("customers");
            builder.Services.AddKeyedSingleton<IGreeter, InformalGreeterService>("friends");
            builder.Services.AddSingleton<CustomerService>();
            builder.Services.AddSingleton<FriendsService>();
                                    
            builder.Services.AddControllers();
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

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
