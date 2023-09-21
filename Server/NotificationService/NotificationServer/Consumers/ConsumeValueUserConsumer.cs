using Event.UserEvents;
using Events.UserServiceEvents.Notification;
using MassTransit;
using SendMail.Interfaces;

namespace NotificationServer.Consumers
{
    public class ConsumeValueUserConsumer : IConsumer<ISendEmailEvent>
    {
        private readonly IEmailSender _emailSender;

        public ConsumeValueUserConsumer(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }
        public async Task Consume(ConsumeContext<ISendEmailEvent> context)
        {
            var data = context.Message;
            if (data != null) 
            {
                _emailSender.SendEmailAsync(data.Email,data.Subject,data.Content);
            }
        }
    }
}
