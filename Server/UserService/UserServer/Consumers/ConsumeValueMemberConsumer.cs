using Application.Models;
using Application.Services;
using Events.ClassroomServiceEvents.Member;
using Events.ClassroomServiceEvents.Member.AddMember;
using Events.ClassroomServiceEvents.Models;
using MassTransit;
using Microsoft.IdentityModel.Tokens;

namespace UserServer.Consumers
{
    public class ConsumeValueMemberConsumer : IConsumer<IConsumeValueMemberEvent>
    {
        private readonly IUnitOfWork_UserService unitOfWork_UserService;
        public ConsumeValueMemberConsumer(IUnitOfWork_UserService unitOfWork_UserService)
        {
            this.unitOfWork_UserService = unitOfWork_UserService;
        }

        public async Task Consume(ConsumeContext<IConsumeValueMemberEvent> context)
        {
            var data = context.Message;
            if (data != null)
            {
                var addMemberIsValidEvent = new
                {
                    IdClassroom = data.idClassroom,
                    NameClassroom = data.NameClassroom,
                    ListMember = new List<MemberEventModel>()
                };
                var cancelAddMemberEvent = new
                {
                    IdClassroom = data.idClassroom,
                    ListMember = new List<MemberEventModel>()
                };

                foreach (var item in data.ListMember)
                {
                    var user = unitOfWork_UserService.UserService.GetUserById(item.IdMember);
                    if (user != null)
                    {
                        var classroomInfor = new AddClassroomInforModel()
                        {
                            IdClassroom = data.idClassroom.ToString(),
                            IdUser = item.IdMember,
                            NameClassroom = data.NameClassroom,
                        };
                        unitOfWork_UserService.ClassroomInforService.AddClassroomInfor(classroomInfor);
                        addMemberIsValidEvent.ListMember.Add(new MemberEventModel()
                        {
                            NameMember = $"{user.FirstName} {user.LastName}",
                            IdMember = item.IdMember,
                            Avatar = user.Avatar
                        });
                    }
                    else
                    {
                        cancelAddMemberEvent.ListMember.Add(new MemberEventModel()
                        {
                            NameMember = $"{user.FirstName} {user.LastName}",
                            IdMember = item.IdMember,
                            Avatar = user.Avatar
                        });
                    }
                }

                if (!addMemberIsValidEvent.ListMember.IsNullOrEmpty())
                {
                    await context.Publish<IAddMemberIsValidEvent>(addMemberIsValidEvent);
                }
                if (!cancelAddMemberEvent.ListMember.IsNullOrEmpty())
                {
                    await context.Publish<ICancelAddMemberEvent>(cancelAddMemberEvent);
                }
            }
        }
    }
}
