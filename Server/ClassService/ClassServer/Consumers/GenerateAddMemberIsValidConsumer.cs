using Application.Models;
using Application.Services;
using Events.ClassroomServiceEvents.Member;
using MassTransit;

namespace ClassServer.Consumers
{
    public class GenerateAddMemberIsValidConsumer : IConsumer<IAddMemberIsValidEvent>
    {
        private readonly IUnitOfWork_ClassroomService unitOfWork_ClassroomService;

        public GenerateAddMemberIsValidConsumer(IUnitOfWork_ClassroomService unitOfWork_ClassroomService)
        {
            this.unitOfWork_ClassroomService = unitOfWork_ClassroomService;
        }

        public async Task Consume(ConsumeContext<IAddMemberIsValidEvent> context)
        {
            var data = context.Message;
            if (data != null)
            {
                var classroom = unitOfWork_ClassroomService._classroomService.GetClassroomById(data.IdClassroom.ToString());
                if (classroom != null)
                {
                    var member = new MemberModel()
                    {
                        idMember = data.IdMember,
                        nameMember = data.NameMember,
                        avatar = data.Avatar,
                    };
                    unitOfWork_ClassroomService._classroomService.UpdateMember(member, data.IdClassroom.ToString());

                }
            }
        }
    }
}
