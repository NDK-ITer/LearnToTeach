using Application.Services;
using Events.ClassroomServiceEvents.Member.MemberLeaveClassroom;
using MassTransit;

namespace ClassServer.Consumers.MemberConsumers.MemberLeaveIsValidConsumer
{
    public class GenerateMemberLeaveIsValidConsumer : IConsumer<ILeaveClassroomIsValidEvent>
    {
        private readonly IUnitOfWork_ClassroomService unitOfWork_ClassroomService;

        public GenerateMemberLeaveIsValidConsumer(IUnitOfWork_ClassroomService unitOfWork_ClassroomService)
        {
            this.unitOfWork_ClassroomService = unitOfWork_ClassroomService;
        }
        public async Task Consume(ConsumeContext<ILeaveClassroomIsValidEvent> context)
        {
            var data = context.Message;
            var check = unitOfWork_ClassroomService._classroomService.RemoveMember(data.IdClassroom, data.IdUser);
            Console.WriteLine(check);
        }
    }
}
