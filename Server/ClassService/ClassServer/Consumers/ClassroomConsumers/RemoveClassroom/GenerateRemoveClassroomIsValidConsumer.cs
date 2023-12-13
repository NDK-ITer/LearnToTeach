using Application.Services;
using Events.ClassroomServiceEvents;
using Events.ClassroomServiceEvents.Classroom.RemoveClassroom;
using MassTransit;
using XAct.Messages;

namespace ClassServer.Consumers.ClassroomConsumers.RemoveClassroom
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
                var classroom = unitOfWork_ClassroomService._classroomService.GetClassroomById(data.IdClassroom);
                foreach (var item in classroom.ListMemberClassroom)
                {
                    if (item.Role == "Member")
                    {
                        await context.Publish<IClassroomSendEmail>(new
                        {
                            IdMessage = Guid.NewGuid(),
                            Email = item.Member.Email,
                            Subject = $"classroom {classroom.Name} have been delete.",
                            Content = $"{classroom.Name} which you are a member have been delete."
                        });
                    }
                }
                unitOfWork_ClassroomService._classroomService.DeleteClassroom(data.IdClassroom);
            }
        }
    }
}
