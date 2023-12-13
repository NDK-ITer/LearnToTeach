using Application.Services;
using Domain.Entities;
using Events.ClassroomServiceEvents;
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
            var classroom = unitOfWork_ClassroomService._classroomService.GetClassroomById(data.IdClassroom);
            var member = unitOfWork_ClassroomService._memberService.GetMemberById(data.IdUser);
            var check = unitOfWork_ClassroomService._classroomService.RemoveMember(data.IdClassroom, data.IdUser);
            if (check == 1)
            {
                await context.Publish<IClassroomSendEmail>(new
                {
                    IdMessage = Guid.NewGuid(),
                    Email = member.Email,
                    Subject = $"classroom {classroom.Name} have been delete.",
                    Content = $"Dear {member.Name}</br>You have been kicked or get out classroom {classroom.Name}."
                });
            }
        }
    }
}
