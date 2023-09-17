using Application.Services;
using Events.ClassroomServiceEvents.Classroom;
using MassTransit;

namespace UserServer.Consumers
{
    public class ConsumeValueClassroomConsumer : IConsumer<IConsumeValueClassroomEvent>
    {
        private readonly IUnitOfWork_UserService unitOfWork_UserService;

        public ConsumeValueClassroomConsumer(IUnitOfWork_UserService unitOfWork_UserService)
        {
            this.unitOfWork_UserService = unitOfWork_UserService;
        }
        public async Task Consume(ConsumeContext<IConsumeValueClassroomEvent> context)
        {
            var data = context.Message;
            if (data != null)
            {
                var checkUserExist = unitOfWork_UserService.UserService.CheckUserIsExist(prop => prop.id.Equals(data.idUserHost));
                if (!checkUserExist)
                {
                    await context.Publish<ICancelAddClassroomEvent>(new
                    {
                        idClassroom = data.idClassroom,
                        description = data.description,
                        idUserHost = data.idUserHost,
                        name = data.name,
                        isPrivate = data.isPrivate,
                    });
                }
            }
        }
    }
}
