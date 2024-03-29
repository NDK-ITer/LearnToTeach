﻿namespace Domain.Entities
{
    public class User
    {
        public string id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FirstEmail { get; set; }
        public string PresentEmail { get; set; }
        public string PhoneNumber { get; set; }
        public string PasswordHash { get; set; }
        public string TokenAccess { get; set; }
        public DateTime? VerifiedDate { get; set; }
        public bool IsVerified { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsLock { get; set; }
        public string RoleId { get; set; }
        public string LinkAvatar { get; set; }
        public string Avatar { get; set; }
        public Role Role { get; set; }
        public List<ClassroomInfor> ListClassroomInfor { get; set; }
    }
}
