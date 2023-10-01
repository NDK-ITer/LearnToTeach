using RabbitMQ_Lib;

namespace UserServer.Models
{
    public class UserEventMessage: GenerateEventMessage
    {
        public readonly string ConfirmEmail = "ConfirmEmail";
        public readonly string ResetPassword = "ResetPassword";
    }
}
