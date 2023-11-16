using Application.Services;
using ClassServer.Consumers;
using ClassServer.Consumers.AddClassroom;
using ClassServer.Consumers.AddMember;
using ClassServer.Consumers.RemoveClassroom;
using ClassServer.Consumers.UpdateUserInfor;
using ClassServer.Models;
using Infrastructure.Context;
using MassTransit;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ClassroomConnectString");
var nameQueue = builder.Configuration.GetConnectionString("SagaBusQueue");

// Add services to the container.
builder.Services.Configure<EndpointConfig>(builder.Configuration.GetSection("EndpointConfig"));
builder.Services.Configure<ServerInfor>(builder.Configuration.GetSection("ServerInfor"));
builder.Services.AddMassTransit(cfg =>
{
    cfg.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
    {
        cfg.ReceiveEndpoint(nameQueue, ep =>
        {
            ep.PrefetchCount = 20;
            ep.ConfigureConsumer<GenerateCancelAddClassroomConsumer>(provider);
            ep.ConfigureConsumer<GenerateAddMemberIsValidConsumer>(provider);
            ep.ConfigureConsumer<GenerateAddClassroomIsValidConsumer>(provider);
            ep.ConfigureConsumer<GenerateCancelAddMemberConsumer>(provider);
            ep.ConfigureConsumer<GetClassroomValueConsumer>(provider);
            ep.ConfigureConsumer<GetMemberValueConsumer>(provider);
            ep.ConfigureConsumer<ConsumeUpdateUserInforConsumer>(provider);
            ep.ConfigureConsumer<GenerateRemoveClassroomIsValidConsumer>(provider);
        });
    }));
    cfg.AddConsumer<GenerateAddMemberIsValidConsumer>();
    cfg.AddConsumer<GenerateAddClassroomIsValidConsumer>();
    cfg.AddConsumer<GenerateCancelAddClassroomConsumer>();
    cfg.AddConsumer<GenerateCancelAddMemberConsumer>();
    cfg.AddConsumer<GetClassroomValueConsumer>();
    cfg.AddConsumer<GetMemberValueConsumer>();
    cfg.AddConsumer<GenerateRemoveClassroomIsValidConsumer>();
    cfg.AddConsumer<ConsumeUpdateUserInforConsumer>();

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
