using Application.Models;
using Application.Services;
using Events.ClassroomServiceEvents.Member;
using Events.ClassroomServiceEvents.Member.AddMember;
using MassTransit;

namespace UserServer.Consumers
{
    public class ConsumeValueMemberConsumer : IConsumer<IConsumeValueMemberEvent>
    {
        private readonly IUnitOfWork_UserService unitOfWork_UserService;
        public ConsumeValueMemberConsumer(IUnitOfWork_UserService unitOfWork_UserService)
        {
            this.unitOfWork_UserService = unitOfWork_UserService;
        }

        public async Task Consume(ConsumeContext<IConsumeValueMemberEvent> context)
        {
            var data = context.Message;
            if (data != null)
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
                        IdMember = data.IdMember,
                        NameClassroom = data.NameClassroom,
                        NameMember = data.NameMember,
                        Avatar = data.Avatar,
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
        }
    }
}
