using Application.Services;
using Events.ClassroomServiceEvents.Member;
using MassTransit;

namespace ClassServer.Consumers
{
    public class GenerateCancelAddMemberConsumer : IConsumer<ICancelAddMemberEvent>
    {
        private readonly IUnitOfWork_ClassroomService unitOfWork_ClassroomService;
        public GenerateCancelAddMemberConsumer(IUnitOfWork_ClassroomService unitOfWork_ClassroomService)
        {
            this.unitOfWork_ClassroomService = unitOfWork_ClassroomService;
        }
        public async Task Consume(ConsumeContext<ICancelAddMemberEvent> context)
        {
            var data = context.Message;
            if (data != null)
            {
                //unitOfWork_ClassroomService._classroomService.RemoveMember(data.idClassroom.ToString(),data.IdMember);
            }
        }
    }
}
