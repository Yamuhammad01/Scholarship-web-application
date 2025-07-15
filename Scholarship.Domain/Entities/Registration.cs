using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarship.Domain.Entities
{
    public class Registration
    {
        public string PasswordHash;

        public int Id { get; set; }
        public string? FullName { get; set; } 
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Gender { get; set; } 
        public string? Password { get; set; }
        //public string ConfirmPassword { get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; }

        public string? UserId { get; set; } // Link to Identity User
    }
}
