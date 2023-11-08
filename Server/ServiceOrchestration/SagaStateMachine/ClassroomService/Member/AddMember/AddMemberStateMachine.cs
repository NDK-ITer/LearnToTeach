using Events.ClassroomServiceEvents.Member.AddMember;
using MassTransit;
using SagaStateMachine.ClassroomService.Member.AddMember;

namespace SagaStateMachine.ClassroomService.Member
{
    public class AddMemberStateMachine : MassTransitStateMachine<AddMemberStateData>
    {
        // 2 states are going to happen
        public State AddMember { get; private set; }
        public State CancelAddMember { get; private set; }
        public State AddMemberIsValid { get; private set; }

        // 2 events are going to happen

        public Event<IAddMemberEvent> AddMemberEvent { get; private set; }
        public Event<ICancelAddMemberEvent> CancelAddMemberEvent { get; private set; }
        public Event<IAddMemberIsValidEvent> AddMemberIsValidEvent { get; private set; }

        public AddMemberStateMachine()
        {
            InstanceState(s => s.CurrentState);
            Event(() => AddMemberEvent, a => a.CorrelateById(m => m.Message.IdClassroom));
            Event(() => CancelAddMemberEvent, a => a.CorrelateById(m => m.Message.IdClassroom));
            Event(() => AddMemberIsValidEvent, a => a.CorrelateById(m => m.Message.IdClassroom));

            Initially(
                When(AddMemberEvent).Then(context =>
                {
                    context.Saga.IdClassroom = context.Message.IdClassroom;
                    context.Saga.ListMember = new List<MemberModel>();
                    foreach (var member in context.Message.ListMember)
                    {
                        context.Saga.ListMember.Add(new MemberModel
                        {
                            //idMemberModel = Guid.NewGuid(),
                            NameMember = member.NameMember,
                            Avatar = member.Avatar,
                            IdMember = member.IdMember,

                        });
                    }
                    context.Saga.NameClassroom = context.Message.NameClassroom;
                }).TransitionTo(AddMember).Publish(context => new ConsumeValueAddMemberEvent(context.Saga)));

            During(AddMember,
                When(AddMemberEvent).Then(context =>
                {
                    context.Saga.IdClassroom = context.Message.IdClassroom;
                    context.Saga.ListMember = new List<MemberModel>();
                    foreach (var member in context.Message.ListMember)
                    {
                        context.Saga.ListMember.Add(new MemberModel
                        {
                            //idMemberModel = Guid.NewGuid(),
                            NameMember = member.NameMember,
                            Avatar = member.Avatar,
                            IdMember = member.IdMember,

                        });
                    }
                    context.Saga.NameClassroom = context.Message.NameClassroom;
                }).TransitionTo(AddMember).Publish(context => new ConsumeValueAddMemberEvent(context.Saga)));

            During(AddMember,
                When(CancelAddMemberEvent).Then(context =>
                {
                    context.Saga.IdClassroom = context.Message.IdClassroom;
                    context.Saga.ListMember = new List<MemberModel>();
                    foreach (var member in context.Message.ListMember)
                    {
                        context.Saga.ListMember.Add(new MemberModel
                        {
                            //idMemberModel = Guid.NewGuid(),
                            NameMember = member.NameMember,
                            Avatar = member.Avatar,
                            IdMember = member.IdMember,

                        });
                    }
                    context.Saga.NameClassroom = context.Message.NameClassroom;
                }).TransitionTo(CancelAddMember));

            During(AddMember,
                When(AddMemberIsValidEvent).Then(context =>
                {
                    context.Saga.IdClassroom = context.Message.IdClassroom;
                    context.Saga.ListMember = new List<MemberModel>();
                    foreach (var member in context.Message.ListMember)
                    {
                        context.Saga.ListMember.Add(new MemberModel
                        {
                            //idMemberModel = Guid.NewGuid(),
                            NameMember = member.NameMember,
                            Avatar = member.Avatar,
                            IdMember = member.IdMember,

                        });
                    }
                    context.Saga.NameClassroom = context.Message.NameClassroom;
                }).TransitionTo(AddMemberIsValid));

            During(AddMemberIsValid,
                When(AddMemberIsValidEvent).Then(context =>
                {
                    context.Saga.IdClassroom = context.Message.IdClassroom;
                    context.Saga.ListMember = new List<MemberModel>();
                    foreach (var member in context.Message.ListMember)
                    {
                        context.Saga.ListMember.Add(new MemberModel
                        {
                            //idMemberModel = Guid.NewGuid(),
                            NameMember = member.NameMember,
                            Avatar = member.Avatar,
                            IdMember = member.IdMember,

                        });
                    }
                    context.Saga.NameClassroom = context.Message.NameClassroom;
                }).TransitionTo(AddMemberIsValid).Publish(context => new ConsumeValueAddMemberEvent(context.Saga)));

            During(AddMemberIsValid,
                When(AddMemberEvent).Then(context =>
                {
                    context.Saga.IdClassroom = context.Message.IdClassroom;
                    context.Saga.ListMember = new List<MemberModel>();
                    foreach (var member in context.Message.ListMember)
                    {
                        context.Saga.ListMember.Add(new MemberModel
                        {
                            //idMemberModel = Guid.NewGuid(),
                            NameMember = member.NameMember,
                            Avatar = member.Avatar,
                            IdMember = member.IdMember,

                        });
                    }
                    context.Saga.NameClassroom = context.Message.NameClassroom;
                }).TransitionTo(AddMember));

            During(AddMemberIsValid,
                When(CancelAddMemberEvent).Then(context =>
                {
                    context.Saga.IdClassroom = context.Message.IdClassroom;
                    context.Saga.ListMember = new List<MemberModel>();
                    foreach (var member in context.Message.ListMember)
                    {
                        context.Saga.ListMember.Add(new MemberModel
                        {
                            //idMemberModel = Guid.NewGuid(),
                            NameMember = member.NameMember,
                            Avatar = member.Avatar,
                            IdMember = member.IdMember,

                        });
                    }
                    context.Saga.NameClassroom = context.Message.NameClassroom;
                }).TransitionTo(CancelAddMember));

            During(CancelAddMember,
                When(AddMemberIsValidEvent).Then(context =>
                {
                    context.Saga.IdClassroom = context.Message.IdClassroom;
                    context.Saga.ListMember = new List<MemberModel>();
                    foreach (var member in context.Message.ListMember)
                    {
                        context.Saga.ListMember.Add(new MemberModel
                        {
                            //idMemberModel = Guid.NewGuid(),
                            NameMember = member.NameMember,
                            Avatar = member.Avatar,
                            IdMember = member.IdMember,

                        });
                    }
                    context.Saga.NameClassroom = context.Message.NameClassroom;
                }).TransitionTo(AddMemberIsValid).Publish(context => new ConsumeValueAddMemberEvent(context.Saga)));

            During(CancelAddMember,
                When(AddMemberEvent).Then(context =>
                {
                    context.Saga.IdClassroom = context.Message.IdClassroom;
                    context.Saga.ListMember = new List<MemberModel>();
                    foreach (var member in context.Message.ListMember)
                    {
                        context.Saga.ListMember.Add(new MemberModel
                        {
                            //idMemberModel = Guid.NewGuid(),
                            NameMember = member.NameMember,
                            Avatar = member.Avatar,
                            IdMember = member.IdMember,

                        });
                    }
                    context.Saga.NameClassroom = context.Message.NameClassroom;
                }).TransitionTo(AddMember));

            During(CancelAddMember,
                When(CancelAddMemberEvent).Then(context =>
                {
                    context.Saga.IdClassroom = context.Message.IdClassroom;
                    context.Saga.ListMember = new List<MemberModel>();
                    foreach (var member in context.Message.ListMember)
                    {
                        context.Saga.ListMember.Add(new MemberModel
                        {
                            //idMemberModel = Guid.NewGuid(),
                            NameMember = member.NameMember,
                            Avatar = member.Avatar,
                            IdMember = member.IdMember,

                        });
                    }
                    context.Saga.NameClassroom = context.Message.NameClassroom;
                }).TransitionTo(CancelAddMember));

        }
    }
}
