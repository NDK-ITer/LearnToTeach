using Application.Models;
using MassTransit;

namespace ServiceComposition.Message
{
    public class ClassroomConsumer : IConsumer<ClassroomModel>
    {
        public object? classroomMessage { get; private set; }
        public async Task Consume(ConsumeContext<ClassroomModel> context)
        {
            classroomMessage = context.Message;
        }
    }
}
