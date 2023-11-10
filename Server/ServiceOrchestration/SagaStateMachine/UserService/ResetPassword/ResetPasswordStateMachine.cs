using Events.UserServiceEvents.User.UserResetPassword;
using MassTransit;

namespace SagaStateMachine.UserService.ResetPassword
{
    public class ResetPasswordStateMachine : MassTransitStateMachine<ResetPasswordStateData>
    {
        public State UserResetPassword { get; private set; }
        public Event<IUserResetPasswordEvent> UserResetPasswordEvent { get; set; }
        public ResetPasswordStateMachine()
        {
            InstanceState(s => s.CurrentState);
            Event(() => UserResetPasswordEvent, a => a.CorrelateById(m => m.Message.idUser));

            Initially(
                When(UserResetPasswordEvent).Then(context =>
                {
                    context.Saga.IdUser = context.Message.idUser;
                    context.Saga.Fullname = context.Message.fullName;
                    context.Saga.Email = context.Message.email;
                    context.Saga.Content = context.Message.content;
                    context.Saga.Subject = context.Message.subject;
                }).TransitionTo(UserResetPassword).Publish(context => new ConsumeResetPasswordEvent(context.Saga)));
            During(UserResetPassword,
                When(UserResetPasswordEvent).Then(context =>
                {
                    context.Saga.IdUser = context.Message.idUser;
                    context.Saga.Fullname = context.Message.fullName;
                    context.Saga.Email = context.Message.email;
                    context.Saga.Content = context.Message.content;
                    context.Saga.Subject = context.Message.subject;
                }).TransitionTo(UserResetPassword).Publish(context => new ConsumeResetPasswordEvent(context.Saga)));

        }
    }
}
