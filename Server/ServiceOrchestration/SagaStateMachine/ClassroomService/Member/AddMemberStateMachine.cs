using Events.ClassroomServiceEvents.Member;
using MassTransit;

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
            Event(() => AddMemberEvent, a => a.CorrelateById(m => m.Message.idClassroom));
            Event(() => CancelAddMemberEvent, a => a.CorrelateById(m => m.Message.idClassroom));

            Initially(
                When(AddMemberEvent).Then(context =>
                {
                    context.Saga.IdClassroom = context.Message.idClassroom;
                    context.Saga.IdMember = context.Message.IdMember;
                }).TransitionTo(AddMember).Publish(context => new ConsumeValueMemberEvent(context.Saga)));

            During(AddMember,
                When(AddMemberEvent).Then(context =>
                {
                    context.Saga.IdClassroom = context.Message.idClassroom;
                    context.Saga.IdMember = context.Message.IdMember;
                }).TransitionTo(AddMember).Publish(context => new ConsumeValueMemberEvent(context.Saga)));

            During(AddMember,
                When(CancelAddMemberEvent).Then(context =>
                {
                    context.Saga.IdClassroom = context.Message.idClassroom;
                    context.Saga.IdMember = context.Message.IdMember;
                }).TransitionTo(CancelAddMember));

            During(AddMember,
                When(AddMemberIsValidEvent).Then(context =>
                {
                    context.Saga.IdClassroom = context.Message.IdClassroom;
                    context.Saga.IdMember = context.Message.IdMember;
                    context.Saga.NameMember = context.Message.NameMember;
                    context.Saga.Avatar = context.Message.Avatar;
                }).TransitionTo(AddMemberIsValid));

        }
    }
}
