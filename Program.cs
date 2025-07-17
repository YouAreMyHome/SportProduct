
using Microsoft.EntityFrameworkCore;
using SportProductMVC.Models;

using Microsoft.AspNetCore.Localization;
using System.Globalization;
var builder = WebApplication.CreateBuilder(args);

// Đăng ký DbContext
builder.Services.AddDbContext<SportProductContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddControllersWithViews();



// Cấu hình localization cho phép nhập số kiểu 1.000.000,00
var supportedCultures = new[] { new CultureInfo("vi-VN") };
var app = builder.Build();
app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("vi-VN"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures
});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
