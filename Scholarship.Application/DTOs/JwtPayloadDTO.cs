using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarship.Application.DTOs
{
     public class JwtPayloadDTO
    {
        public int UserId { get; set; }
        public string Email { get; set; }
       // public string UserName { get; set; }
       // public string Role { get; set; } // Optional
    }
}
