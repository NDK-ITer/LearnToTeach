using Events.ClassroomServiceEvents;
using MassTransit;

namespace SagaStateMachine.ClassroomService.Notification
{
    public class ClassroomEmailStateMachine : MassTransitStateMachine<ClassroomEmailStateData>
    {
        public State SendEmail { get; private set; }
        public Event<IClassroomSendEmail> SendEmailEvent { get; private set; }
        public ClassroomEmailStateMachine()
        {
            InstanceState(s => s.CurrentState);
            Event(() => SendEmailEvent, a => a.CorrelateById(m => m.Message.IdMessage));

            Initially(
                When(SendEmailEvent).Then(context =>
                {
                    context.Saga.IdMessage = context.Message.IdMessage;
                    context.Saga.Email = context.Message.Email;
                    context.Saga.Subject = context.Message.Subject;
                    context.Saga.Content = context.Message.Content;
                }).Publish(context => new ConsumeClassroomEmailEvent(context.Saga)));
        }
    }
}
