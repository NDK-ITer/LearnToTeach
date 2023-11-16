using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using JwtAuthenticationManager;

var builder = WebApplication.CreateBuilder(args);


builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("ocelot.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();
builder.Services.AddOcelot(builder.Configuration);
builder.Services.AddCustomJwtAuthentication();
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CORSPolicy",policy =>
    {
        policy.WithOrigins("https://localhost:3000")
               .AllowAnyHeader()
               .AllowAnyMethod()
               .AllowCredentials();
    });
});

var app = builder.Build();
await app.UseOcelot();

app.UseAuthentication();
app.UseCors("CORSPolicy");
app.UseAuthorization();
app.Run();
