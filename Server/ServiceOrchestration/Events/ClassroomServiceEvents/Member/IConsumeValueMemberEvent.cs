﻿namespace Events.ClassroomServiceEvents.Member
{
    public interface IConsumeValueMemberEvent
    {
        public Guid idClassroom { get; }
        public string NameClassroom { get; }
        public string NameMember { get; }
        public string Avatar { get;}
    }
}
