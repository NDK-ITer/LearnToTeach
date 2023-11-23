using Application.Services;
using ClassServer.Consumers;
using ClassServer.Models;
using Infrastructure.Context;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ_Lib;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ClassroomConnectString");
var nameQueue = builder.Configuration.GetConnectionString("SagaBusQueue");
var queue = builder.Configuration.GetSection("EndpointConfig");

// Add services to the container.
builder.Services.Configure<EndpointConfig>(queue);
builder.Services.AddMassTransit(cfg =>
{
    cfg.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
    {
        //cfg.Host(new Uri(RabbitMQConfig.RabbitMQURL), hst =>
        //{
        //    hst.Username(RabbitMQConfig.UserName);
        //    hst.Password(RabbitMQConfig.Password);
        //});
        cfg.ReceiveEndpoint(nameQueue, ep =>
        {
            ep.PrefetchCount = 10;
            ep.ConfigureConsumer<GenerateCancelAddClassroomConsumer>(provider);
            ep.ConfigureConsumer<GetClassroomValueConsumer>(provider);
        });
    }));
    cfg.AddConsumer<GenerateCancelAddClassroomConsumer>();
    cfg.AddConsumer<GetClassroomValueConsumer>();
});

builder.Services.AddControllers();
builder.Services.AddMemoryCache();
builder.Services.AddHealthChecks();
builder.Services.AddTransient<ClassroomEventMessage>();
builder.Services.AddDbContext<ClassroomDbContext>(option => option.UseSqlServer(connectionString));
builder.Services.AddTransient<IUnitOfWork_ClassroomService, UnitOfWork_ClassroomService>();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();