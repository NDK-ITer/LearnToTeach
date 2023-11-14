using Events;
using FIleStoreServer.Model;
using FIleStoreServer.Model.NewFolder;
using MassTransit;

namespace FIleStoreServer.Consumers
{
    public class ConsumeUploadFileConsumer : IConsumer<IConsumerUploadFileEvent>
    {
        private readonly ServerName serverName;
        private readonly EventMessage eventMessage;

        public ConsumeUploadFileConsumer(ServerName serverName, EventMessage eventMessage)
        {
            this.serverName = serverName;
            this.eventMessage = eventMessage;
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

                    }
                    else if (data.Event == eventMessage.Delete)
                    {

                    }
                }
                else if (data.ServerName == serverName.ClassroomServer)
                {
                    if (data.Event == eventMessage.Create || data.Event == eventMessage.Update)
                    {

                    }
                    else if (data.Event == eventMessage.Delete)
                    {

                    }
                }
            }
        }
    }
}
