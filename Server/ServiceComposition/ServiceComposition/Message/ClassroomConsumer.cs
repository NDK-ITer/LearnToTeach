using MassTransit;
using Application.Models;

namespace ServiceComposition.Message
{
    public class ClassroomConsumer : IConsumer<ClassroomModel>
    {
        public object? ClassroomMessage { get; private set; }
        public async Task Consume(ConsumeContext<ClassroomModel> context)
        {
            ClassroomMessage = context.Message;
        }
    }
}
