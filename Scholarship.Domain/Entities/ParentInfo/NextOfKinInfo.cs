using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarship.Domain.Entities.ParentInfo
{
    public class NextOfKinInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Occupation { get; set; }
        public string? Email { get; set; }
        public string Rank { get; set; }
        public string Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Relationship { get; set; }
    }
}
