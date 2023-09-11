﻿using Events.ClassroomEvents;
using MassTransit;

namespace SagaStateMachine.Classrooms.AddClassroomState
{
    public class ClassroomStateData : SagaStateMachineInstance
    {
        public Guid CorrelationId { get; set; }
        public string? CurrentState { get; set; }
        public Guid IdClassroom { get; set; }
        public string? Description { get; set; }
        public string? IdUserHost { get; set; }
        public string? Key { get; set; }
        public string? Name { get; set; }
        public bool IsPrivate { get; set; }
        public string? IdMember { get; set; }
    }
}
