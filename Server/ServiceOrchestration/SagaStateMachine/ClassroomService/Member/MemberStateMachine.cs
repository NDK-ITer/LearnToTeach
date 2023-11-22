using Events.ClassroomServiceEvents.Member;
using MassTransit;

namespace SagaStateMachine.ClassroomService.Member
{
    public class MemberStateMachine : MassTransitStateMachine<MemberStateData>
    {
        // 2 states are going to happen
        public State AddMember { get; private set; }

        // 2 events are going to happen

        public Event<IMemberEvent> AddMemberEvent { get; private set; }

        public MemberStateMachine()
        {
            InstanceState(s => s.CurrentState);
            Event(() => AddMemberEvent, a => a.CorrelateById(m => m.Message.IdMessage));

            Initially(
                When(AddMemberEvent).Then(context =>
                {
                    context.Saga.IdMessage = context.Message.IdMessage;
                    context.Saga.IdMember = context.Message.IdMember;
                    context.Saga.IdClassroom = context.Message.IdClassroom;
                    context.Saga.NameClassroom = context.Message.NameClassroom;
                    context.Saga.NameMember = context.Message.NameMember;
                    context.Saga.Avatar = context.Message.Avatar;
                    context.Saga.Event = context.Message.Event;
                }).Publish(context => new ConsumeValueMemberEvent(context.Saga)));

            During(AddMember,
                When(AddMemberEvent).Then(context =>
                {
                    context.Saga.IdMessage = context.Message.IdMessage;
                    context.Saga.IdMember = context.Message.IdMember;
                    context.Saga.IdClassroom = context.Message.IdClassroom;
                    context.Saga.IdMember = context.Message.IdMember;
                    context.Saga.NameClassroom = context.Message.NameClassroom;
                    context.Saga.NameMember = context.Message.NameMember;
                    context.Saga.Avatar = context.Message.Avatar;
                    context.Saga.Event = context.Message.Event;
                }).Publish(context => new ConsumeValueMemberEvent(context.Saga)));
        }
    }
}
