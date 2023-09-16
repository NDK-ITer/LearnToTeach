using Events.ClassroomServiceEvents.Member;
using MassTransit;

namespace SagaStateMachine.ClassroomService.Member
{
    public class MemberStateMachine : MassTransitStateMachine<MemberStateData>
    {
        // 2 states are going to happen
        public State AddMember { get; private set; }
        public State CancelAddMember { get; private set; }

        // 2 events are going to happen

        public Event<IAddMemberEvent> AddMemberEvent { get; private set; }
        public Event<ICancelAddMemberEvent> CancelAddMemberEvent { get; private set; }

        public MemberStateMachine()
        {
            InstanceState(s => s.CurrentState);
            Event(() => AddMemberEvent, a => a.CorrelateById(m => m.Message.idClassroom));
            Event(() => CancelAddMemberEvent, a => a.CorrelateById(m => m.Message.idClassroom));

            // A message coming from classroom service
            Initially(
                When(AddMemberEvent).Then(context =>
                {
                    context.Saga.IdClassroom = context.Message.idClassroom;
                    context.Saga.IdMember = context.Message.IdMember;
                }).TransitionTo(AddMember).Publish(context => context.Saga));

            // During AddClassroomEvent some other events might occurred 
            During(AddMember,
                When(CancelAddMemberEvent).Then(context =>
                {
                    context.Saga.IdClassroom = context.Message.idClassroom;
                    context.Saga.IdMember = context.Message.IdMember;
                }).TransitionTo(CancelAddMember));
        }
    }
}
