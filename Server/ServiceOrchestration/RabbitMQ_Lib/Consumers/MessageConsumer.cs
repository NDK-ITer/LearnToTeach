using MassTransit;
using RabbitMQ_Lib.Models;

namespace RabbitMQ_Lib.Consumers
{
    public class MessageConsumer : IConsumer<MessageModel>
    {
        public async Task Consume(ConsumeContext<MessageModel> context)
        {
            Console.WriteLine(context.Message.ObjectInMessage);
        }
    }
}
