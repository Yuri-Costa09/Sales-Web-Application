using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SalesWebApplication.Data;
using System.Configuration;
using MySqlConnector;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<SalesWebApplicationContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("SalesWebApplicationContext"),
        new MySqlServerVersion("10.4.32-MariaDB"),
        mysqlOptions => mysqlOptions.MigrationsAssembly("SalesWebApplication") 

        
));

// Add seeding service.
builder.Services.AddScoped<SeedingService>();


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    using (var scope = app.Services.CreateScope())
    {
        var seedingService = scope.ServiceProvider.GetRequiredService<SeedingService>();
        seedingService.Seed();
    }

    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
