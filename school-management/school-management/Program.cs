using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using school_management.Data;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<school_managementContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("school_managementContext")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
