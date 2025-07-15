using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarship.Application.DTOs
{
    public class AcademicLevelDTO
    {
        
        public string Institution { get; set; }
        public string InsitutionAddress { get; set; }
        public string Department { get; set; }
        public string Qualification { get; set; }
        public string Course { get; set; }
        public string YearOfAdmission { get; set; }
        public string CategoryOfStudy { get; set; }
        public string CurrentLevel { get; set; }
        public string CGPA { get; set; }
    }
}
