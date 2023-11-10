using Events.ClassroomServiceEvents.Classroom;
using Events.UserServiceEvents.User.UpdateUserInfor;
using MassTransit;

namespace SagaStateMachine.UserService.UpdateUserInfor
{
    public class UpdateUserInforStateMachine: MassTransitStateMachine<UpdateUserInforStateData>
    {
        public State UpdateUserInfo { get; private set; }
        public Event<IUpdateUserInforEvent> UpdateUserInforEvent { get; private set; }
        public UpdateUserInforStateMachine()
        {
            InstanceState(s => s.CurrentState);
            Event(() => UpdateUserInforEvent, a => a.CorrelateById(m => m.Message.IdUser));

            Initially(
                When(UpdateUserInforEvent).Then(context =>
                {
                    context.Saga.IdUser = context.Message.IdUser;
                    context.Saga.FullName = context.Message.FullName;
                    context.Saga.Avatar = context.Message.Avatar;
                }).TransitionTo(UpdateUserInfo).Publish(context => new ConsumeUpdateUserInforEvent(context.Saga)));
            During(UpdateUserInfo,
                When(UpdateUserInforEvent).Then(context =>
                {
                    context.Saga.IdUser = context.Message.IdUser;
                    context.Saga.FullName = context.Message.FullName;
                    context.Saga.Avatar = context.Message.Avatar;
                }).Publish(context => new ConsumeUpdateUserInforEvent(context.Saga)));
        }
    }
}
