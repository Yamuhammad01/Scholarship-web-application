using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarship.Domain.Entities
{
    public class Certificate
    {
        public int Id { get; set; }
        public string FilePath { get; set; }
        public string FileType { get; set; }  // Optional: Admission Letter, CGPA, etc.
        public DateTime UploadedAt { get; set; }
    }
}
