using Application.Services;
using Infrastructure.Context;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using SendMail.ClassDefine;
using SendMail.Interfaces;
using UserServer.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("AuthConnectString");
// Add services to the container.
builder.Services.Configure<EndpointConfig>(builder.Configuration.GetSection("Endpoints"));
builder.Services.AddMassTransit(mass =>
{
    mass.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("amqp://guest:guest@localhost:5672");
    });

});
// add Entity framework
builder.Services.AddControllers();
builder.Services.AddMemoryCache();
builder.Services.AddDbContext<AuthenticationDbContext>(option => option.UseSqlServer(connectionString));
builder.Services.AddTransient<IUnitOfWork_UserService, UnitOfWork_UserService>();
builder.Services.AddTransient<IEmailSender, EmailSender>();
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
