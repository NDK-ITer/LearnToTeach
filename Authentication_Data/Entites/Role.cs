using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication_Data.Entites
{
    public class Role
    {
        [Key]
        public string id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string NormalizeName { get; set; }
        public List<UserRole> UserRoles { get; set; }
    }
}
