using Microsoft.AspNetCore.Authentication.Cookies;
using Pretech.Software.RConfig.Crypto.Abstract;
using Pretech.Software.RConfig.Crypto.Concrete;
using Pretech.Software.RConfig.UI.DependencyExtentions;
using Pretech.Software.RConfig.UI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAllContext();
await builder.Services.DBMigrationConfigure();
builder.Services.AddAllDependencyInjections();



builder.Services.AddTransient<ProjectModel>();
builder.Services.AddTransient<SectionsModel>();
builder.Services.AddTransient<IJsonCrypto, JsonCrypto>();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie((q) =>
                {

                    q.LoginPath = "/Auth/Login";
                    q.LogoutPath = "/Account/Logoff";
                    q.AccessDeniedPath = "/Auth/Denied";

                });

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

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
