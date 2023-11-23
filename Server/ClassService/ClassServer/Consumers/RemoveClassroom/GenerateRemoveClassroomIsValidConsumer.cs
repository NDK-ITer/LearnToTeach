using Application.Services;
using Events.ClassroomServiceEvents.Classroom.RemoveClassroom;
using MassTransit;

namespace ClassServer.Consumers.RemoveClassroom
{
    public class GenerateRemoveClassroomIsValidConsumer : IConsumer<IRemoveClassroomIsValidEvent>
    {
        private readonly IUnitOfWork_ClassroomService unitOfWork_ClassroomService;
        public GenerateRemoveClassroomIsValidConsumer(IUnitOfWork_ClassroomService unitOfWork_ClassroomService)
        {
            this.unitOfWork_ClassroomService = unitOfWork_ClassroomService;
        }
        public async Task Consume(ConsumeContext<IRemoveClassroomIsValidEvent> context)
        {
            var data = context.Message;
            if (data != null)
            {
                unitOfWork_ClassroomService._classroomService.DeleteClassroom(data.IdClassroom);
            }
        }
    }
}
