using Application.Services;
using Events.ClassroomEvents;
using MassTransit;

namespace UserServer.Consumers
{
    public class GenerateAddClassroomConsumer : IConsumer<IAddClassroomEvent>
    {
        private readonly IUnitOfWork_UserService unitOfWork_UserService;

        public GenerateAddClassroomConsumer(IUnitOfWork_UserService unitOfWork_UserService)
        {
            this.unitOfWork_UserService = unitOfWork_UserService;
        }
        public async Task Consume(ConsumeContext<IAddClassroomEvent> context)
        {
            var data = context.Message;
            if (data != null)
            {
                var userHostIsExist = unitOfWork_UserService.UserService.CheckUserIsExist(c => c.id == data.idUserHost);
                if (!userHostIsExist)
                {
                    await context.Publish<ICancelAddClassroomEvent>(new
                    {
                        idClassroom = data.idClassroom,
                        description = data.description,
                        idUserHost = data.idUserHost,
                        name = data.name,
                        isPrivate = data.isPrivate
                    });
                }
            }
        }
    }
}
