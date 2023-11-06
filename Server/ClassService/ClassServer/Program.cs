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
        cfg.ReceiveEndpoint(nameQueue, ep =>
        {
            ep.PrefetchCount = 20;
            ep.ConfigureConsumer<GenerateCancelAddClassroomConsumer>(provider);
            ep.ConfigureConsumer<GenerateAddMemberIsValidConsumer>(provider);
            ep.ConfigureConsumer<GenerateCancelAddMemberConsumer>(provider);
            ep.ConfigureConsumer<GetClassroomValueConsumer>(provider);
            ep.ConfigureConsumer<GetMemberValueConsumer>(provider);
        });
    }));
    cfg.AddConsumer<GenerateAddMemberIsValidConsumer>();
    cfg.AddConsumer<GenerateCancelAddClassroomConsumer>();
    cfg.AddConsumer<GenerateCancelAddMemberConsumer>();
    cfg.AddConsumer<GetClassroomValueConsumer>();
    cfg.AddConsumer<GetMemberValueConsumer>();

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
