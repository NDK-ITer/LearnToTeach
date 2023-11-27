using Events.MultiServiceUseEvent;
using MassTransit;

namespace SagaStateMachine.StoreFileService
{
    public class UploadFileStateMachine : MassTransitStateMachine<UploadFileStateData>
    {
        public State UploadFile {  get; private set; }
        public Event<IUploadFileEvent> UploadFileEvent { get; set; }
        public UploadFileStateMachine()
        {
            InstanceState(s => s.CurrentState);
            Event(() => UploadFileEvent, a => a.CorrelateById(m => m.Message.IdMessage));

            Initially(
                When(UploadFileEvent).Then(context =>
                {
                    context.Saga.IdMessage = context.Message.IdMessage;
                    context.Saga.IdObject = context.Message.IdObject;
                    context.Saga.FileByteString = context.Message.FileByteString;
                    context.Saga.ServerName = context.Message.ServerName;
                    context.Saga.Event = context.Message.Event;
                }).TransitionTo(UploadFile).Publish(context => new ConsumerUploadFileEvent(context.Saga)));

            During(UploadFile,
                When(UploadFileEvent).Then(context =>
                {
                    context.Saga.IdMessage = context.Message.IdMessage;
                    context.Saga.IdObject = context.Message.IdObject;
                    context.Saga.FileByteString = context.Message.FileByteString;
                    context.Saga.ServerName = context.Message.ServerName;
                    context.Saga.Event = context.Message.Event;
                }).Publish(context => new ConsumerUploadFileEvent(context.Saga)));
        }
    }
}
