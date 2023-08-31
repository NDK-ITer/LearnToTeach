using MassTransit;
using ServiceComposition.Message;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMassTransit(mass =>
{
    mass.AddConsumer<MessageConsumer>();
    mass.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("amqp://guest:guest@localhost:5672");
        cfg.ReceiveEndpoint("classroom-service-queue", ep => {
            ep.ConfigureConsumer<MessageConsumer>(context);
        });
    });
});
builder.Services.AddLogging();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
