using CarDealer.Data.Extensions;
using CarDealer.Service.Extensions;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Reflection;
var builder = WebApplication.CreateBuilder(args);
var assembly = Assembly.GetExecutingAssembly().FullName;
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.LoadDataExtensions(builder.Configuration);
builder.Services.LoadServiceExtensions();

builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();

app.UseRouting();


app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
        name: "Admin",
        areaName: "Admin",
        pattern: "Admin/{controller=Auth}/{action=Login}/{id?}"
    );
    endpoints.MapDefaultControllerRoute();
});

app.Run();
