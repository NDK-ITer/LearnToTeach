using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using JwtAuthenticationManager;

var builder = WebApplication.CreateBuilder(args);


builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("ocelot.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();
builder.Services.AddOcelot(builder.Configuration);
builder.Services.AddCustomJwtAuthentication();
<<<<<<< HEAD
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CORSPolicy",policy =>
    {
        policy.WithOrigins("*")
               .AllowAnyMethod().AllowAnyHeader();
            
    });
});

=======
>>>>>>> c371bd57433eea646f2cfcabbb8b0c95349c5809
var app = builder.Build();
await app.UseOcelot();

app.UseAuthentication();
app.UseAuthorization();
app.UseCors("CORSPolicy");
app.Run();
