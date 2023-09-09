using MassTransit;
using RabbitMQ_Lib.Consumers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddMassTransit(mass =>
//{
//    mass.AddConsumer<MessageConsumer>();
//    mass.UsingRabbitMq((context, cfg) =>
//    {
//        cfg.Host("amqp://guest:guest@localhost:5672");

//        cfg.ReceiveEndpoint("classroom-service-queue", ep =>
//        {
//            ep.ConfigureConsumer<MessageConsumer>(context);
//        });
//        cfg.ReceiveEndpoint("user-service-queue", ep =>
//        {
//            ep.ConfigureConsumer<MessageConsumer>(context);
//        });
//    });
//});
builder.Services.AddMassTransit(cfg =>
{
    cfg.AddBus(provider => RabbitMQ_Lib.RabbitMQ.ConfigureBus(provider));
    
});
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
