using FIleStoreServer.Model;
using MassTransit;
using RabbitMQ_Lib;
using RepositoryFile.Repository.ClassDefines;
using RepositoryFile.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);
var nameQueue = builder.Configuration.GetConnectionString("SagaBusQueue");
// Add services to the container.

builder.Services.AddControllers();
builder.Services.Configure<Address>(builder.Configuration.GetSection("Address"));
builder.Services.Configure<EndpointConfig>(builder.Configuration.GetSection("EndpointConfig"));
builder.Services.AddTransient<IFileService, FileService>();
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
            //ep.ConfigureConsumer<ConsumeValueClassroomConsumer>(provider);
        });

    }));
    // Configuration "Consumer"
    //cfg.AddConsumer<ConsumeValueClassroomConsumer>();
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
