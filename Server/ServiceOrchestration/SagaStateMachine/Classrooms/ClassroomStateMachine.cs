using Events.ClassroomEvents;
using MassTransit;

namespace SagaStateMachine.Classrooms
{
    public class ClassroomStateMachine : MassTransitStateMachine<ClassroomStateData>
    {
        // 4 states are going to happen
        public State AddClassroom { get; private set; }
        public State AddMemeber { get; private set; }

        // 4 events are going to happen

        public Event<IAddClassroomEvent> AddClassroomEvent { get; private set; }
        public Event<IAddMemberEvent> AddMemberEvent { get; private set; }

        public ClassroomStateMachine() { }
    }
}
