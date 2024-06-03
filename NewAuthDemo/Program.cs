using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication()
    .AddBearerToken(IdentityConstants.BearerScheme);
builder.Services.AddAuthorizationBuilder();

builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlite("Datasource=adminapp.db"));

builder.Services.AddIdentityCore<AdminUser>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddApiEndpoints();

var app = builder.Build();

app.MapIdentityApi<AdminUser>();


app.MapGet("/greet", (ClaimsPrincipal user) => $"Welcome {user.Identity!.Name}")
    .RequireAuthorization();

app.Run();


class AdminUser : IdentityUser { }

class AppDbContext : IdentityDbContext<AdminUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}