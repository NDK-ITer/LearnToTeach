﻿using Events.ClassroomServiceEvents.Member;
using Events.ClassroomServiceEvents.Member.AddMember;
using MassTransit;

namespace SagaStateMachine.ClassroomService.Member
{
    public class MemberStateMachine : MassTransitStateMachine<MemberStateData>
    {
        // 2 states are going to happen
        public State AddMember { get; private set; }
        public State CancelAddMember { get; private set; }
        public State AddMemberIsValid { get; private set; }

        // 2 events are going to happen

        public Event<IMemberEvent> AddMemberEvent { get; private set; }
        public Event<ICancelAddMemberEvent> CancelAddMemberEvent { get; private set; }
        public Event<IAddMemberIsValidEvent> AddMemberIsValidEvent { get; private set; }

        public MemberStateMachine()
        {
            InstanceState(s => s.CurrentState);
            Event(() => AddMemberEvent, a => a.CorrelateById(m => m.Message.IdClassroom));
            Event(() => CancelAddMemberEvent, a => a.CorrelateById(m => m.Message.IdClassroom));
            Event(() => AddMemberIsValidEvent, a => a.CorrelateById(m => m.Message.IdClassroom));

            Initially(
                When(AddMemberEvent).Then(context =>
                {
                    context.Saga.IdClassroom = context.Message.IdClassroom;
                    context.Saga.IdMember = context.Message.IdMember;
                    context.Saga.NameClassroom = context.Message.NameClassroom;
                    context.Saga.NameMember = context.Message.NameMember;
                    context.Saga.Avatar = context.Message.Avatar;
                    context.Saga.Event = context.Message.Event;
                }).Publish(context => new ConsumeValueMemberEvent(context.Saga)));

            Initially(
                When(AddMemberIsValidEvent).Then(context =>
                {
                    context.Saga.IdClassroom = context.Message.IdClassroom;
                    context.Saga.IdMember = context.Message.IdMember;
                    context.Saga.NameClassroom = context.Message.NameClassroom;
                    context.Saga.NameMember = context.Message.NameMember;
                    context.Saga.Avatar = context.Message.Avatar;
                }));

            During(AddMember,
                When(AddMemberEvent).Then(context =>
                {
                    context.Saga.IdClassroom = context.Message.IdClassroom;
                    context.Saga.IdMember = context.Message.IdMember;
                    context.Saga.NameClassroom = context.Message.NameClassroom;
                    context.Saga.NameMember = context.Message.NameMember;
                    context.Saga.Avatar = context.Message.Avatar;
                    context.Saga.Event = context.Message.Event;
                }).Publish(context => new ConsumeValueMemberEvent(context.Saga)));

            During(AddMember,
                When(AddMemberIsValidEvent).Then(context =>
                {
                    context.Saga.IdClassroom = context.Message.IdClassroom;
                    context.Saga.IdMember = context.Message.IdMember;
                    context.Saga.NameClassroom = context.Message.NameClassroom;
                    context.Saga.NameMember = context.Message.NameMember;
                    context.Saga.Avatar = context.Message.Avatar;
                }));
        }
    }
}
