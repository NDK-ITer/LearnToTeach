using Application.Services;
using Events.MultiServiceUseEvent;
using Events.UserServiceEvents;
using Events.UserServiceEvents.User.ConfirmUser;
using Events.UserServiceEvents.User.UpdateUserInfor;
using Events.UserServiceEvents.User.UserResetPassword;
using MassTransit;
using Microsoft.IdentityModel.Tokens;
using UserServer.Models;

namespace UserServer.Consumers
{
    public class GetValueUserConsumer : IConsumer<IGetValueUserEvent>
    {
        private readonly UserEventMessage _userEventMessage;
        private readonly IUnitOfWork_UserService _userService;
        public GetValueUserConsumer(UserEventMessage userEventMessage, IUnitOfWork_UserService unitOfWork_UserService)
        {
            _userEventMessage = userEventMessage;
            _userService = unitOfWork_UserService;
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
                    if (!data.avatar.IsNullOrEmpty())
                    {
                        await context.Publish<IUploadFileEvent>(new
                        {
                            IdMessage = Guid.NewGuid(),
                            IdObject = data.id.ToString(),
                            Event = _userEventMessage.Update,
                            FileByteString = data.avatar,
                            ServerName = data.serverName
                        });
                    }
                    var checkEmail = _userService.UserService.CheckUserIsExist(e => e.PresentEmail==data.email);
                    if (!checkEmail)
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
                }
                else if (data.eventMessage == _userEventMessage.Create)
                {
                    await context.Publish<IConfirmUserEvent>(new
                    {
                        idUser = data.id,
                        fullName = data.fullName,
                        email = data.email,
                        subject = data.subject,
                        content = data.content,
                    });
                    if (!data.avatar.IsNullOrEmpty())
                    {
                        await context.Publish<IUploadFileEvent>(new
                        {
                            IdMessage = Guid.NewGuid(),
                            IdObject = data.id.ToString(),
                            Event = _userEventMessage.Update,
                            FileByteString = data.avatar,
                            ServerName = data.serverName
                        });
                    }
                }
            }
            
        }
    }
}
