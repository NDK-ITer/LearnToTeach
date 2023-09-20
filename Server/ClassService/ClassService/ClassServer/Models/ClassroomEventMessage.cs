using RabbitMQ_Lib;

namespace ClassServer.Models
{
    public class ClassroomEventMessage : GenerateEventMessage
    {
        public readonly string AddMember = "AddMember";
    }
}
