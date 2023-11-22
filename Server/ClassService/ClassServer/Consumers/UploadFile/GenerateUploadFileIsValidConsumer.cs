using Application.Models;
using Application.Services;
using ClassServer.Models;
using Domain.Entities;
using Events.ClassroomServiceEvents.Classroom;
using MassTransit;

namespace ClassServer.Consumers.UploadFile
{
    public class GenerateUploadFileIsValidConsumer : IConsumer<IClassroomServiceUploadIsValid>
    {
        private readonly IUnitOfWork_ClassroomService unitOfWork_ClassroomService;
        private readonly ClassroomEventMessage classroomEvent;

        public GenerateUploadFileIsValidConsumer(IUnitOfWork_ClassroomService unitOfWork_ClassroomService, ClassroomEventMessage classroomEvent)
        {
            this.unitOfWork_ClassroomService = unitOfWork_ClassroomService;
            this.classroomEvent = classroomEvent;
        }
        public async Task Consume(ConsumeContext<IClassroomServiceUploadIsValid> context)
        {
            var data = context.Message;
            if (data != null)
            {
                var classroomUpdate = new UpdateClassroomModel()
                {
                    idClassroom = data.IdClassroom,
                    linkAvatar = data.LinkImage,
                    avatarClassroom = data.NameImage
                };
                var classroom = unitOfWork_ClassroomService._classroomService.UpdateClassroom(classroomUpdate);
                await context.Publish<IClassroomEvent>(new
                {
                    idMessage = Guid.NewGuid(),
                    idClassroom = classroom.Id,
                    description = classroom.Description,
                    name = classroom.Name,
                    linkAvatar = classroom.LinkAvatar,
                    avatar = classroom.Avatar,
                    eventMessage = classroomEvent.Update
                });
            }
        }
    }
}
