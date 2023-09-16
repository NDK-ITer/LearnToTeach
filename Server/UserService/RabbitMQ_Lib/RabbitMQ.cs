using MassTransit.RabbitMqTransport;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace RabbitMQ_Lib
{
    public class RabbitMQ
    {
        public static IBusControl ConfigureBus(
            IServiceProvider serviceProvider, Action<IRabbitMqBusFactoryConfigurator, IRabbitMqHost>? action = null)
        {
            return Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                cfg.Host(new Uri(RabbitMQConfig.RabbitMQURL), hst =>
                {
                    hst.Username(RabbitMQConfig.UserName);
                    hst.Password(RabbitMQConfig.Password);
                });

                cfg.ConfigureEndpoints(serviceProvider.GetRequiredService<IBusRegistrationContext>());
            });
        }
    }
}
