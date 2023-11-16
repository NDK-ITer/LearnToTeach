using Application.Models;
using Application.Services;
using Events.ClassroomServiceEvents.Member;
using Events.ClassroomServiceEvents.Member.AddMember;
using Events.ClassroomServiceEvents.Member.MemberLeaveClassroom;
using MassTransit;
using UserServer.Models;

namespace UserServer.Consumers
{
    public class ConsumeValueMemberConsumer : IConsumer<IConsumeValueMemberEvent>
    {
        private readonly IUnitOfWork_UserService unitOfWork_UserService;
        private readonly UserEventMessage userEventMessage;

        public ConsumeValueMemberConsumer(IUnitOfWork_UserService unitOfWork_UserService, UserEventMessage userEventMessage)
        {
            this.unitOfWork_UserService = unitOfWork_UserService;
            this.userEventMessage = userEventMessage;
        }

        public async Task Consume(ConsumeContext<IConsumeValueMemberEvent> context)
        {
            var data = context.Message;
            if (data != null)
            {
                if (data.Event == userEventMessage.Create)
                {
                    var user = unitOfWork_UserService.UserService.GetUserById(data.IdMember);
                    if (user != null)
                    {
                        unitOfWork_UserService.ClassroomInforService.AddClassroomInfor(new AddClassroomInforModel()
                        {
                            IdClassroom = data.IdClassroom.ToString(),
                            IdUser = data.IdMember,
                            NameClassroom = data.NameClassroom,
                        });
                        await context.Publish<IAddMemberIsValidEvent>(new
                        {
                            IdClassroom = data.IdClassroom,
                            IdMember = user.id,
                            NameMember = $"{user.FirstName} {user.LastName}",
                            Avatar = user.Avatar,
                            LinkAvatar = user.LinkAvatar,
                        });
                    }
                    else
                    {
                        await context.Publish<ICancelAddMemberEvent>(new
                        {
                            IdClassroom = data.IdClassroom,
                            IdMember = data.IdMember,
                            NameClassroom = data.NameClassroom,
                            NameMember = data.NameMember,
                            Avatar = data.Avatar,
                        });
                    }
                }
                else if (data.Event == userEventMessage.Delete)
                {
                    var check = unitOfWork_UserService.ClassroomInforService.DeleteClassroomInfor(data.IdMember, data.IdClassroom.ToString());
                    if (check == 1)
                    {
                        await context.Publish<ILeaveClassroomIsValidEvent>(new
                        {
                            IdClassroom = data.IdClassroom,
                            IdMember = data.IdMember,
                        });
                    }
                }
            }
        }
    }
}
