using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarship.Domain.Entities
{
    public class AcademicLevel
    {
        public int Id { get; set; }
        public string Institution { get; set; }
        public string InsitutionAddress { get; set; }
        public string Department {  get; set; }
        public string Qualification {  get; set; }
        public string Course { get; set; }
        public string YearOfAdmission { get; set; }
        public string CategoryOfStudy { get; set; }
        public string CurrentLevel { get; set; }
        public string CGPA { get; set; }
    }
}
