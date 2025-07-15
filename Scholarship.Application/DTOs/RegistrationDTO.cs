using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarship.Application.DTOs
{
    public record RegistrationDTO
    {
        //public string? UserId;

       // public int Id { get; set; }
        public string? FullName { get; set; } 
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        
        [MinLength(6, ErrorMessage = "The password length must me more than 6 characters.")]
        public string? Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string? ConfirmPassword { get; set; }
        public string? Gender { get; set; } 
        public DateTime? DateOfBirth { get; set; }
        //public string UserId { get; set; }


    }
}
