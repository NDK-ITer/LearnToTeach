using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtAuthenticationManager.Models
{
    public class JwtUserInfor
    {
        public string Id { get; set; }
        public string Fullname { get; set; }
        public string Role { get; set; }
    }
}
