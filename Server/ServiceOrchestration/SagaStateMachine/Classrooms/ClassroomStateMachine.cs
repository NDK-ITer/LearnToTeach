﻿using Events.ClassroomEvents;
using MassTransit;
using SagaStateMachine.Classrooms.AddClassroomState;

namespace SagaStateMachine.Classrooms
{
    public class ClassroomStateMachine : MassTransitStateMachine<ClassroomStateData>
    {
        // 2 states are going to happen
        public State AddClassroom { get; private set; }
        public State CancelAddClassroom { get; private set; }

        // 2 events are going to happen

        public Event<IAddClassroomEvent> AddClassroomEvent { get; private set; }
        public Event<ICancelAddClassroomEvent> CancelAddClassroomEvent { get; private set; }

        public ClassroomStateMachine()
        {
            InstanceState(s => s.CurrentState);
            Event(() => AddClassroomEvent, a => a.CorrelateById(m => m.Message.idClassroom));
            Event(() => CancelAddClassroomEvent, a => a.CorrelateById(m => m.Message.idClassroom));

            // A message coming from classroom service
            Initially(
                When(AddClassroomEvent).Then(context =>
                {
                    context.Saga.IdClassroom = context.Message.idClassroom;
                    context.Saga.Name = context.Message.name;
                    context.Saga.Description = context.Message.description;
                    context.Saga.IsPrivate = context.Message.isPrivate;
                    context.Saga.Key = context.Message.key;
                    context.Saga.IdMember = context.Message.IdMember;
                }).TransitionTo(AddClassroom).Publish(context => context.Saga));

            // During AddClassroomEvent some other events might occurred 
            During(AddClassroom,
                When(CancelAddClassroomEvent).Then(context =>
                {
                    context.Saga.IdClassroom = context.Message.idClassroom;
                    context.Saga.Name = context.Message.name;
                    context.Saga.Description = context.Message.description;
                    context.Saga.IsPrivate = context.Message.isPrivate;
                    context.Saga.Key = context.Message.key;
                    context.Saga.IdMember = context.Message.IdMember;
                }).TransitionTo(CancelAddClassroom));
        }
    }
}
