using Events.ClassroomServiceEvents.Classroom;
using Events.StoreFileServiceEvent;
using Events.UserServiceEvents.User;
using FileStoreServer.FileMethods;
using FIleStoreServer.Model;
using MassTransit;

namespace FIleStoreServer.Consumers
{
    public class ConsumeUploadFileConsumer : IConsumer<IConsumerUploadFileEvent>
    {
        private readonly ServerName serverName;
        private readonly EventMessage eventMessage;
        private readonly ImageMethod imageMethod;

        public ConsumeUploadFileConsumer(ServerName serverName, EventMessage eventMessage, ImageMethod imageMethod)
        {
            this.serverName = serverName;
            this.eventMessage = eventMessage;
            this.imageMethod = imageMethod;
        }
        public async Task Consume(ConsumeContext<IConsumerUploadFileEvent> context)
        {
            var data = context.Message;
            if (data != null)
            {
                if (data.ServerName == serverName.UserServer)
                {
                    if (data.Event == eventMessage.Create || data.Event == eventMessage.Update)
                    {
                        var imageInfor = imageMethod.SaveImage("Files",data.FileByteString,data.Id.ToString());
                        await context.Publish<IUserServiceUploadIsValid>(new
                        {
                            Id = data.Id,
                            Link = imageInfor.Item1,
                            NameImage = imageInfor.Item2,
                        });
                    }
                    else if (data.Event == eventMessage.Delete)
                    {

                    }
                }
                else if (data.ServerName == serverName.ClassroomServer)
                {
                    if (data.Event == eventMessage.Create || data.Event == eventMessage.Update)
                    {
                        var imageInfor = imageMethod.SaveImage("Files", data.FileByteString, data.Id.ToString());
                        await context.Publish<IClassroomServiceUploadIsValid>(new
                        {
                            Id = data.Id,
                            Link = imageInfor.Item1,
                            NameImage = imageInfor.Item2,
                        });
                    }
                    else if (data.Event == eventMessage.Delete)
                    {

                    }
                }
            }
        }
    }
}
