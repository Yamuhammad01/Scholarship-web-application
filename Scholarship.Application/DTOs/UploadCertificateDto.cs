using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scholarship.Domain.Enums;

namespace Scholarship.Application.DTOs
{
    public class UploadCertificateDto
    {
        public CertificateType FileType { get; set; }
        public IFormFile File { get; set; }
    }
}
