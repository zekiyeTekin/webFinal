using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WebFinal.Service.Core;
using WebFinal.Service.Data;
using WebFinal.Service.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    //builder.UseLazyLoadingProxies();
    ));
//"Server=localhost;Database=WebFinalDB;Trusted_Connection=true" genlde bu yazýlýr

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "WebApplication.auth";
        options.ExpireTimeSpan =TimeSpan.FromDays(7);
        options.SlidingExpiration = false;
        options.LoginPath = "/Account/Login";
        options.LogoutPath = "/Account/Logout";
        options.AccessDeniedPath = "/Home/AccessDenied";
    });

builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<GiyimService>();
builder.Services.AddScoped<AdminService>();
builder.Services.AddScoped<TakiService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
