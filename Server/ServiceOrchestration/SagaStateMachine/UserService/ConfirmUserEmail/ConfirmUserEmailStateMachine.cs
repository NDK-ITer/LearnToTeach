using Events.UserServiceEvents.User.ConfirmUser;
using MassTransit;

namespace SagaStateMachine.UserService.ConfirmUserEmail
{
    public class ConfirmUserEmailStateMachine : MassTransitStateMachine<ConfirmUserEmailStateData>
    {
        public State ConfirmUser { get; private set; }
        public Event<IConfirmUserEvent> ConfirmUserEvent { get; set; }
        public ConfirmUserEmailStateMachine()
        {
            InstanceState(s => s.CurrentState);
            Event(() => ConfirmUserEvent, a => a.CorrelateById(m => m.Message.idUser));

            Initially(
                When(ConfirmUserEvent).Then(context =>
                {
                    context.Saga.IdUser = context.Message.idUser;
                    context.Saga.Fullname = context.Message.fullName;
                    context.Saga.Email = context.Message.email;
                    context.Saga.Content = context.Message.content;
                    context.Saga.Subject = context.Message.subject;
                }).TransitionTo(ConfirmUser).Publish(context => new ConsumeConfirmEmailEvent(context.Saga)));
            During(ConfirmUser,
                When(ConfirmUserEvent).Then(context =>
                {
                    context.Saga.IdUser = context.Message.idUser;
                    context.Saga.Fullname = context.Message.fullName;
                    context.Saga.Email = context.Message.email;
                    context.Saga.Content = context.Message.content;
                    context.Saga.Subject = context.Message.subject;
                }).TransitionTo(ConfirmUser).Publish(context => new ConsumeConfirmEmailEvent(context.Saga)));
        }
    }
}
