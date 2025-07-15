using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarship.Domain.Entities.ParentInfo
{
    public class FathersInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Occupation { get; set; }
        public string? Email { get; set; }
        public string Rank { get; set; }
        public string WorkingPlaceAddress { get; set; }
        public string? PhoneNumber { get; set; }
      
    }
}
