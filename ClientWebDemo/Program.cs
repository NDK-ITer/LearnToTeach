using ClienWebDemo;
using Flurl.Http.Configuration;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);
IHttpContextAccessor _httpContextAccessor = new HttpContextAccessor();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//    .AddCookie(options =>
//    {
//        options.LoginPath = "/Authentication/Login";
//        options.Cookie.Name = "LoginPath";
//    });
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSingleton<IFlurlClientFactory, PerBaseUrlFlurlClientFactory>();
builder.Services.AddHttpClient();

builder.Services.AddHttpClient("ApiGateway", httpClient =>
{
    httpClient.BaseAddress = new Uri("https://localhost:9000/");
    httpClient.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
    if (!string.IsNullOrEmpty(_httpContextAccessor.HttpContext.Request.Cookies[NameToken.NameOfAuthenticateToken]))
    {
        var token = _httpContextAccessor.HttpContext.Request.Cookies[NameToken.NameOfAuthenticateToken];
        httpClient.DefaultRequestHeaders.Add(HeaderNames.Authorization, $"bearer {token}");
    }
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseRouting();
app.UseAuthorization();
app.UseAuthentication();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
