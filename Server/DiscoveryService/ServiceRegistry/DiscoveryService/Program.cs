using ConsulSetting.Configurations;
using ConsulSetting.ClassDefines;
using ConsulSetting.Interfaces;
using Consul;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<IHostedService, ConsulRegisterService>();
builder.Services.Configure<MenuConfiguration>(builder.Configuration.GetSection("Menu"));
builder.Services.Configure<ConsulConfiguration>(builder.Configuration.GetSection("Consul"));

var consulAddress = builder.Configuration.GetSection("Consul")["url"];

builder.Services.AddSingleton<IConsulClient, ConsulClient>(provider =>
    new ConsulClient(config => config.Address = new Uri(consulAddress)));
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
