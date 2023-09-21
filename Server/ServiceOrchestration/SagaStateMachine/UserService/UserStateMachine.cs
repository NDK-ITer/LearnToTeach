using Events.ClassroomServiceEvents.Classroom;
using Events.UserServiceEvents.User;
using MassTransit;

namespace SagaStateMachine.UserService
{
    public class UserStateMachine : MassTransitStateMachine<UserStateData>
    {
        public State ConfirmUser { get; private set; }
        public Event<IConfirmUserEvent> ConfirmUserEvent { get; set; }
        public UserStateMachine()
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
                }).TransitionTo(ConfirmUser).Publish(context => new SendMailEvent(context.Saga)));
        }
    }
}
