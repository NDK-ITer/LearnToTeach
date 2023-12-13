using Event.ClassroomServiceEvents.Notification;
using MassTransit;
using SendMail.Interfaces;

namespace NotificationServer.Consumers
{
    public class ConsumeClassroomEmailConsumer : IConsumer<IConsumeClassroomEmail>
    {
        private readonly IEmailSender _emailSender;

        public ConsumeClassroomEmailConsumer(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }
        public async Task Consume(ConsumeContext<IConsumeClassroomEmail> context)
        {
            var data = context.Message;
            if (data != null)
            {
                _emailSender.SendEmailAsync(data.Email, data.Subject, data.Content);
            }
        }
    }
}
