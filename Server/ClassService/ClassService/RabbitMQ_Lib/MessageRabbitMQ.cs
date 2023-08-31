using MassTransit;

namespace RabbitMQ_Lib
{
    public class MessageRabbitMQ
    {
        private readonly IBus bus;

        public MessageRabbitMQ(IBus bus)
        {
            this.bus = bus;
        }
        public async Task SendAsync<T>(string nameQueue, T message) where T : class
        {
            //Uri uri = new Uri($"rabbitmq://localhost/{nameQueue}");
            //var endPoint = await bus.GetSendEndpoint(uri);
            //await endPoint.Send(message);
            await bus.Publish(message);
        }
    }
}
