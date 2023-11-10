using Events.UserServiceEvents;
using Events.UserServiceEvents.User;
using Events.UserServiceEvents.User.UpdateUserInfor;
using MassTransit;
using UserServer.Models;

namespace UserServer.Consumers
{
    public class GetValueUserConsumer : IConsumer<IGetValueUserEvent>
    {
        private readonly UserEventMessage _userEventMessage;

        public GetValueUserConsumer(UserEventMessage userEventMessage)
        {
            _userEventMessage = userEventMessage;
        }
        public async Task Consume(ConsumeContext<IGetValueUserEvent> context)
        {
            var data = context.Message;
            if (data != null) 
            {
                if (data.eventMessage == _userEventMessage.ConfirmEmail)
                {
                    await context.Publish<IConfirmUserEvent>(new
                    {
                        idUser = data.id,
                        fullName = data.fullName,
                        email = data.email,
                        subject = data.subject,
                        content = data.content,
                    });
                }
                else if (data.eventMessage == _userEventMessage.ResetPassword)
                {
                    await context.Publish<IUserResetPasswordEvent>(new
                    {
                        idUser = data.id,
                        fullName = data.fullName,
                        email = data.email,
                        subject = data.subject,
                        content = data.content,
                    });
                }
                else if (data.eventMessage == _userEventMessage.Update)
                {
                    await context.Publish<IUpdateUserInforEvent>(new
                    {
                        IdUser = data.id,
                        FullName = data.fullName,
                        Avatar = data.avatar,
                    });
                }
            }
            
        }
    }
}
