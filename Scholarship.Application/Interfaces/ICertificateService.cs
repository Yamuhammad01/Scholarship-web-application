using Scholarship.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarship.Application.Interfaces
{
    public interface ICertificateService
    {
        Task<string> UploadCertificateAsync(UploadCertificateDto dto);
    }
}
