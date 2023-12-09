using ClassServer.Models;
using Events.ClassroomServiceEvents.Classroom;
using Events.MultiServiceUseEvent;
using MassTransit;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ClassServer.Consumers
{
    public class GetClassroomValueConsumer : IConsumer<IGetValueClassroomEvent>
    {
        private readonly IOptions<ServerInfor> _serverInfor;
        private readonly ClassroomEventMessage _classroomStateMessage;
        public GetClassroomValueConsumer(IOptions<ServerInfor> serverInfor, ClassroomEventMessage classroomStateMessage)
        {
            _serverInfor = serverInfor;
            _classroomStateMessage = classroomStateMessage;
        }

        public async Task Consume(ConsumeContext<IGetValueClassroomEvent> context)
        {
            var data = context.Message;
            if (data is not null)
            {
                await context.Publish<IClassroomEvent>(new
                {
                    idMessage = data.idMessage,
                    idClassroom = data.idClassroom,
                    description = data.description,
                    idUserHost = data.idUserHost,
                    name = data.name,
                    isPrivate = data.isPrivate,
                    eventMessage = data.eventMessage,
                });
                if (!data.avatar.IsNullOrEmpty() || data.eventMessage == _classroomStateMessage.Delete)
                {
                    await context.Publish<IUploadFileEvent>(new
                    {
                        IdMessage = Guid.NewGuid(),
                        IdObject = data.idClassroom,
                        FileByteString = data.avatar,
                        Event = data.eventMessage,
                        ServerName = _serverInfor.Value.Name
                    });
                }
                
            }
        }
    }
}
