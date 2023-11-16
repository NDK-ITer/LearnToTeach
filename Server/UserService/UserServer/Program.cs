using Application.Services;
using FileStoreServer.FileMethods;
using Infrastructure.Context;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using RabbitMQ_Lib;
using SendMail.ClassDefine;
using SendMail.Interfaces;
using UserServer.Consumers;
using UserServer.Consumers.UploadFile;
using UserServer.Extensions;
using UserServer.Models;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("AuthConnectString");
var nameQueue = builder.Configuration.GetConnectionString("SagaBusQueue");

// Add from "appsettings.json"
builder.Services.Configure<EndpointConfig>(builder.Configuration.GetSection("EndpointConfig"));
builder.Services.Configure<Address>(builder.Configuration.GetSection("Address"));
builder.Services.Configure<ServerInfor>(builder.Configuration.GetSection("ServerInfor"));
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CORSPolicy", policy =>
    {
        policy.WithOrigins("https://localhost:3000")
               .AllowAnyHeader()
               .AllowAnyMethod()
               .AllowCredentials();
    });
});
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
            ep.ConfigureConsumer<ConsumeValueMemberConsumer>(provider);
            ep.ConfigureConsumer<GetValueUserConsumer>(provider);
            ep.ConfigureConsumer<GenerateUploadFileIsValidConsumer>(provider);
        });
        
    }));
    // Configuration "Consumer"
    cfg.AddConsumer<ConsumeValueClassroomConsumer>();
    cfg.AddConsumer<ConsumeValueMemberConsumer>();
    cfg.AddConsumer<GetValueUserConsumer>();
    cfg.AddConsumer<GenerateUploadFileIsValidConsumer>();
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
builder.Services.AddDbContext<UserServiceDbContext>(option => option.UseSqlServer(connectionString));
builder.Services.AddTransient<IUnitOfWork_UserService, UnitOfWork_UserService>();
builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.AddTransient<UserEventMessage>();
builder.Services.AddTransient<ImageMethod>();
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseSession();

app.UseCors("CORSPolicy");

app.Run();
