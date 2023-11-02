using Application.Services;
using Events.ClassroomServiceEvents.Member;
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
                    await context.Publish<IAddMemberIsValidEvent>(new
                    {
                        IdClassroom = data.idClassroom,
                        IdMember = data.IdMember,
                        NameMember = $"{user.FirstName} {user.LastName}",
                        Avatar = user.Avatar
                    });
                }
                else
                {
                    await context.Publish<ICancelAddMemberEvent>(new
                    {
                        IdClassroom = data.idClassroom,
                        IdMember = data.IdMember
                    });
                }
            }
        }
    }
}
