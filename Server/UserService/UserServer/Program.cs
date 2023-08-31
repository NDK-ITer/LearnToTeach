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
        cfg.Host("localhost", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });
    });

});
builder.Services.AddControllers();
builder.Services.AddControllers();
// add Entity framework
builder.Services.AddDbContext<AuthenticationDbContext>(option => option.UseSqlServer(connectionString));
builder.Services.AddTransient<IUnitOfWork_UserService, UnitOfWork_UserService>();
builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.AddMemoryCache();
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
