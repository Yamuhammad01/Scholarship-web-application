using Scholarship.Application.DTOs;
using Scholarship.Application.Interfaces;
using Scholarship.Infrastructure.Persistence;
using Scholarship.Domain.Entities;
using Scholarship.Domain.Enums; 
using System;
using System.IO;
using System.Threading.Tasks;

namespace Scholarship.Application.Services
{
    public class CertificateService : ICertificateService
    {
        private readonly ApplicationDbContext _context;
        private readonly string _webRootPath;

        public CertificateService(ApplicationDbContext context, string webRootPath)
        {
            _context = context;
            _webRootPath = webRootPath;
        }

        public async Task<string> UploadCertificateAsync(UploadCertificateDto dto)
        {
            if (dto.File == null || dto.File.Length == 0)
                throw new ArgumentException("No file provided");

            // Folder based on the enum value (e.g., AdmissionLetter, CgpaResult, etc.)
            var subFolder = dto.FileType.ToString();
            var uploadDir = Path.Combine(_webRootPath, "certificates", subFolder);

            if (!Directory.Exists(uploadDir))
                Directory.CreateDirectory(uploadDir);

            var uniqueFileName = $"{Guid.NewGuid()}_{dto.File.FileName}";
            var fullPath = Path.Combine(uploadDir, uniqueFileName);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                await dto.File.CopyToAsync(stream);
            }

            var certificate = new Certificate
            {
                FilePath = Path.Combine("certificates", subFolder, uniqueFileName).Replace("\\", "/"),
                FileType = dto.FileType.ToString(),
                UploadedAt = DateTime.UtcNow
            };

            _context.Certificates.Add(certificate);
            await _context.SaveChangesAsync();

            return certificate.FilePath;
        }
    }
}
