// Start
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyFirstCoreWebSite.Models;
using ServiceLayer;
using ServiceLayer.IServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var config = builder.Configuration["AppSettingData:SettingKey"];

var conn = builder.Configuration.GetConnectionString("conn");

builder.Services.AddDbContext<TestDBMAJwtMigrationContext>(options => options.UseSqlServer(conn));

builder.Services.Configure<AppSettingData>(builder.Configuration.GetSection("AppSettingData"));

// DI
builder.Services.AddTransient<ITransient, EmployeeDI>();
builder.Services.AddScoped<IScope, EmployeeDI>();
builder.Services.AddSingleton<ISingleton, EmployeeDI>();


var app = builder.Build(); // Build

// 3 >
// Transient >> Every time new instance create thay when hit request
// Scope > One instance per HTTP req, tab change karu tyare new instance create thase
// Singleton >> Single instance entire your application


//___________________________________________________
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // Enable use static file

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run(); // Run
