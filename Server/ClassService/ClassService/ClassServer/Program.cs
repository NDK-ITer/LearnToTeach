using Application.Services;
using ClassServer.Models;
using Infrastructure.Context;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using RabbitMQ_Lib.Consumers;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ClassroomConnectString");

// Add services to the container.
//builder.Services.Configure<EndpointConfig>(builder.Configuration.GetSection("Endpoints"));
builder.Services.AddMassTransit(mass =>
{
    mass.AddConsumer<MessageConsumer>();
    mass.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("amqp://guest:guest@localhost:5672");
        cfg.ReceiveEndpoint("classroom-service-queue", ep =>
        {
            ep.ConfigureConsumer<MessageConsumer>(context);
        });
    });

});

builder.Services.AddControllers();
builder.Services.AddMemoryCache();
builder.Services.AddHealthChecks();
builder.Services.AddDbContext<ClassroomDbContext>(option => option.UseSqlServer(connectionString));
builder.Services.AddTransient<IUnitOfWork_ClassroomService, UnitOfWork_ClassroomService>();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
