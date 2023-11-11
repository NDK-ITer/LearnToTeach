using Application.Models;
using Application.Services;
using Events.ClassroomServiceEvents.Classroom;
using MassTransit;

namespace ClassServer.Consumers.AddClassroom
{
    public class GenerateAddClassroomIsValidConsumer : IConsumer<IAddClassroomIsValidEvent>
    {
        private readonly IUnitOfWork_ClassroomService unitOfWork_ClassroomService;

        public GenerateAddClassroomIsValidConsumer(IUnitOfWork_ClassroomService unitOfWork_ClassroomService)
        {
            this.unitOfWork_ClassroomService = unitOfWork_ClassroomService;
        }
        public async Task Consume(ConsumeContext<IAddClassroomIsValidEvent> context)
        {
            var data = context.Message;
            if (data != null)
            {
                var updateClassroomModel = new ClassroomUpdateModel()
                {

                };
            }
        }
    }
}
