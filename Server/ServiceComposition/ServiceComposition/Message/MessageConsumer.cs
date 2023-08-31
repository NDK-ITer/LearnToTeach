using Application.Models;
using MassTransit;

namespace ServiceComposition.Message
{
    public class MessageConsumer : IConsumer<ClassroomModel>
    {
        public object classroomModelMessage { get; private set; }
        public async Task Consume(ConsumeContext<ClassroomModel> context)
        {
            //var message = context.Message;
            classroomModelMessage = context.Message;
            //return Task.CompletedTask;
        }
    }
}
