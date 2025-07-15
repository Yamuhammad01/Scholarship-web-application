using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Scholarship.Application.DTOs;
using Scholarship.Application.Interfaces;
using Scholarship.Application.Helpers;
using Scholarship.Infrastructure.Persistence;

namespace Scholarship.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CertificatesController : ControllerBase
    {
        private readonly ICertificateService _certificateService;
        private readonly ApplicationDbContext _context;
        private readonly string _webRootPath;

        public CertificatesController(ICertificateService certificateService, ApplicationDbContext context, IWebHostEnvironment env)
        {
            _certificateService = certificateService;
            _context = context;
            _webRootPath = env.WebRootPath;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadCertificate([FromForm] UploadCertificateDto dto)
        {
            var filePath = await _certificateService.UploadCertificateAsync(dto);
            return Ok(new { Message = "File uploaded successfully", FilePath = filePath });

        }
        [HttpGet("view/{id}")]
        public async Task<IActionResult> ViewCertificate(int id)
        {
            var certificate = await _context.Certificates.FindAsync(id);
            if (certificate == null)
                return NotFound("Certificate not found");

            var fullPath = Path.Combine(_webRootPath, certificate.FilePath);

            if (!System.IO.File.Exists(fullPath))
                return NotFound("File not found on disk");

            var contentType = MimeTypeHelper.GetMimeType(fullPath);
            var stream = new FileStream(fullPath, FileMode.Open, FileAccess.Read);

            return File(stream, contentType);
        }

       
    }
}
