using Application.Services;
using Infrastructure.Context;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using RabbitMQ_Lib;
using SendMail.ClassDefine;
using SendMail.Interfaces;
using UserServer.Consumers;
using UserServer.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("AuthConnectString");
var nameQueue = builder.Configuration.GetConnectionString("SagaBusQueue");
// Add services to the container.
builder.Services.Configure<EndpointConfig>(builder.Configuration.GetSection("Endpoints"));
builder.Services.AddMassTransit(cfg =>
{
    cfg.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
    {
        cfg.Host(new Uri(RabbitMQConfig.RabbitMQURL), hst =>
        {
            hst.Username(RabbitMQConfig.UserName);
            hst.Password(RabbitMQConfig.Password);
        });
        cfg.ConfigureEndpoints(provider.GetRequiredService<IBusRegistrationContext>());
    }));
    cfg.AddConsumer<ConsumeValueClassroomConsumer>();

});
// add Entity framework
builder.Services.AddControllers();
builder.Services.AddMemoryCache();
builder.Services.AddDbContext<AuthenticationDbContext>(option => option.UseSqlServer(connectionString));
builder.Services.AddTransient<IUnitOfWork_UserService, UnitOfWork_UserService>();
builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.AddTransient<UserEventMessage>();
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
