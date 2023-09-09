using MassTransit;
using ServiceComposition.Message;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMassTransit(mass =>
{
    mass.AddConsumer<ClassroomConsumer>();
    mass.AddConsumer<UserConsumer>();
    mass.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("amqp://guest:guest@localhost:5672");

        cfg.ReceiveEndpoint("classroom-service-queue", ep =>
        {
            ep.ConfigureConsumer<ClassroomConsumer>(context);
        });
        cfg.ReceiveEndpoint("user-service-queue", ep => 
        {
            ep.ConfigureConsumer<UserConsumer>(context);
        });
    });
});
//builder.Services.AddHttpClient("", c => c.BaseAddress = new Uri(""));
//builder.Services.AddHttpClient("UserServer", c => c.BaseAddress = new Uri("https://localhost:9001"));
//builder.Services.AddHttpClient("ClassroomServer", c => c.BaseAddress = new Uri("https://localhost:9002"));

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
