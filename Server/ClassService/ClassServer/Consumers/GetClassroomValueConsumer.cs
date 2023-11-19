using ClassServer.Models;
using Events.ClassroomServiceEvents.Classroom;
using Events.MultiServiceUseEvent;
using MassTransit;
using Microsoft.Extensions.Options;

namespace ClassServer.Consumers
{
    public class GetClassroomValueConsumer : IConsumer<IGetValueClassroomEvent>
    {
        private readonly IOptions<ServerInfor> _serverInfor;

        public GetClassroomValueConsumer(IOptions<ServerInfor> serverInfor)
        {
            _serverInfor = serverInfor;
        }

        public async Task Consume(ConsumeContext<IGetValueClassroomEvent> context)
        {
            var data = context.Message;
            if (data is not null)
            {
                await context.Publish<IClassroomEvent>(new
                {
                    idClassroom = data.idClassroom,
                    description = data.description,
                    idUserHost = data.idUserHost,
                    name = data.name,
                    isPrivate = data.isPrivate,
                    eventMessage = data.eventMessage,
                });

                await context.Publish<IUploadFileEvent>(new
                {
                    Id = data.idClassroom,
                    FileByteString = data.avatar,
                    Event = data.eventMessage,
                    ServerName = _serverInfor.Value.Name
                });
            }
        }
    }
}
