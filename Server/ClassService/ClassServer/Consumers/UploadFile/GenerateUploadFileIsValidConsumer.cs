using Application.Models;
using Application.Services;
using Events.ClassroomServiceEvents.Classroom;
using MassTransit;

namespace ClassServer.Consumers.UploadFile
{
    public class GenerateUploadFileIsValidConsumer : IConsumer<IClassroomServiceUploadIsValid>
    {
        private readonly IUnitOfWork_ClassroomService unitOfWork_ClassroomService;

        public GenerateUploadFileIsValidConsumer(IUnitOfWork_ClassroomService unitOfWork_ClassroomService)
        {
            this.unitOfWork_ClassroomService = unitOfWork_ClassroomService;
        }
        public async Task Consume(ConsumeContext<IClassroomServiceUploadIsValid> context)
        {
            var data = context.Message;
            if (data != null)
            {
                var classroomUpdate = new ClassroomUpdateModel()
                {
                    idClassroom = data.Id.ToString(),
                    linkAvatar = data.Link,
                    avatarClassroom = data.NameImage
                };
                unitOfWork_ClassroomService._classroomService.UpdateClassroom(classroomUpdate);
            }
        }
    }
}
