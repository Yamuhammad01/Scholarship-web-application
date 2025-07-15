using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarship.Application.DTOs
{
    public class BiodataDTO
    {
        
        public string Surname { get; set; }
        public string Firstname { get; set; }
        public string Othernames { get; set; }
        public string? Gender { get; set; }
        public string Email { get; set; }
        public string? AcademicLevel { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string StateofOrigin { get; set; }
        public string LGA { get; set; }
        public string ParmanentAddress { get; set; }
        public string PostalAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string? MaritalStatus { get; set; }
        public string? PhysicallyChallenged { get; set; }
    }
}
