using Events.ClassroomServiceEvents.Classroom;
using MassTransit;

namespace SagaStateMachine.ClassroomService.Classroom
{
    public class ClassroomStateMachine : MassTransitStateMachine<ClassroomStateData>
    {
        public State AddClassroom { get; private set; }
        public Event<IClassroomEvent> AddClassroomEvent { get; private set; }
        public ClassroomStateMachine()
        {
            InstanceState(s => s.CurrentState);
            Event(() => AddClassroomEvent, a => a.CorrelateById(m => m.Message.idMessage));
            // A message coming from classroom service
            Initially(
                When(AddClassroomEvent).Then(context =>
                {
                    context.Saga.IdMessage = context.Message.idMessage;
                    context.Saga.IdClassroom = context.Message.idClassroom;
                    context.Saga.Name = context.Message.name;
                    context.Saga.Avatar = context.Message.avatar;
                    context.Saga.LinkAvatar = context.Message.linkAvatar;
                    context.Saga.Description = context.Message.description;
                    context.Saga.IsPrivate = context.Message.isPrivate;
                    context.Saga.IdUserHost = context.Message.idUserHost;
                    context.Saga.EventMessage = context.Message.eventMessage;
                }).TransitionTo(AddClassroom).Publish(context => new ConsumeValueClassroomEvent(context.Saga)));

            During(AddClassroom,
                When(AddClassroomEvent).Then(context =>
                {
                    context.Saga.IdClassroom = context.Message.idClassroom;
                    context.Saga.Name = context.Message.name;
                    context.Saga.Avatar = context.Message.avatar;
                    context.Saga.LinkAvatar = context.Message.linkAvatar;
                    context.Saga.Description = context.Message.description;
                    context.Saga.IsPrivate = context.Message.isPrivate;
                    context.Saga.IdUserHost = context.Message.idUserHost;
                    context.Saga.EventMessage = context.Message.eventMessage;
                }).TransitionTo(AddClassroom).Publish(context => new ConsumeValueClassroomEvent(context.Saga)));
        }
    }
}
