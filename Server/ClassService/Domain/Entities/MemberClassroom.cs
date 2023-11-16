﻿namespace Domain.Entities
{
    public class MemberClassroom
    {
        public string IdUser { get; set; }
        public string? Name { get; set; }
        public string? LinkAvatar { get; set; }
        public string? Avatar { get; set; }
        public string IdClass { get; set; }
        public string? Role { get; set; }
        public string? Description { get; set; }
        public Classroom? classroom { get; set; }
    }
}
