using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication_Data.Entites
{
    public class User
    {
        [Key]
        public string id { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FirstEmail { get; set; }
        public string PresentEmail { get; set; }
        public string PasswordHash { get; set; }
        public DateTime Birthday { get; set; }
        public bool IsLock { get; set; }
        public List<UserRole> UserRoles { get; set; }

    }
}
