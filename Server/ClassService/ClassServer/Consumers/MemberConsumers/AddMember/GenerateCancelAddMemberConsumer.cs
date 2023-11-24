using Application.Services;
using Events.ClassroomServiceEvents.Member.AddMember;
using MassTransit;

namespace ClassServer.Consumers.MemberConsumers.AddMember
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
                unitOfWork_ClassroomService._classroomService.RemoveMember(data.IdClassroom.ToString(), data.IdMember);
            }
        }
    }
}
