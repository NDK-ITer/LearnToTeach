using Application.Services;
using Infrastructure.Context;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using RabbitMQ_Lib;
using SendMail.ClassDefine;
using SendMail.Interfaces;
using UserServer.Consumers;
using UserServer.Extensions;
using UserServer.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("AuthConnectString");
var nameQueue = builder.Configuration.GetConnectionString("SagaBusQueue");

// Add from "appsettings.json"
builder.Services.Configure<EndpointConfig>(builder.Configuration.GetSection("EndpointConfig"));
builder.Services.Configure<Address>(builder.Configuration.GetSection("Address"));
// Configuration "MassTransit" to use "RabbitMQ"
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
        // Add endpiont to receive message in "RabbitMQ"
        cfg.ReceiveEndpoint(nameQueue, ep =>
        {
            ep.PrefetchCount = 10;
            ep.ConfigureConsumer<ConsumeValueClassroomConsumer>(provider);
            ep.ConfigureConsumer<GetValueUserConsumer>(provider);
        });
        
    }));
    // Configuration "Consumer"
    cfg.AddConsumer<ConsumeValueClassroomConsumer>();
    cfg.AddConsumer<GetValueUserConsumer>();
});
// Configuration "Session" to store some value
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(SessionInforConfig.SessionTimeOut);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddControllers();
builder.Services.AddMemoryCache();
//
builder.Services.AddDbContext<AuthenticationDbContext>(option => option.UseSqlServer(connectionString));
builder.Services.AddTransient<IUnitOfWork_UserService, UnitOfWork_UserService>();
builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.AddTransient<UserEventMessage>();
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseSession();

app.Run();
