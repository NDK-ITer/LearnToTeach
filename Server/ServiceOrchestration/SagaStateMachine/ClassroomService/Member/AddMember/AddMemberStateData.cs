﻿using MassTransit;

namespace SagaStateMachine.ClassroomService.Member.AddMember
{
    public class AddMemberStateData : SagaStateMachineInstance
    {
        public Guid CorrelationId { get; set; }
        public string? CurrentState { get; set; }
        public Guid IdClassroom { get; set; }
        public string? IdMember { get; set; }
        public string? NameClassroom { get; set; }
        public string? NameMember { get; set; }
        public string? Avatar { get; set; }
    }
}
