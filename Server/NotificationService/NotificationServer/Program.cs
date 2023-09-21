using MassTransit;
using NotificationServer.Consumers;
using RabbitMQ_Lib;
using SendMail.ClassDefine;
using SendMail.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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
    }));
    cfg.AddConsumer<ConsumeValueUserConsumer>();
});
builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
