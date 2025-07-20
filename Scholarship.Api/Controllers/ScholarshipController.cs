using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Exchange.WebServices.Data;
using Scholarship.Application.DTOs;
using Scholarship.Application.Interfaces;
using Scholarship.Domain.Entities;
using System.Security.Claims;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Scholarship.Api.Controllers
{
   
    [ApiController]
    [Route("api/[controller]")]
    public class ScholarshipController : ControllerBase
    {
        private readonly IStudentService _service;
       // private readonly UserManager<IdentityUser> _userManager;

        public ScholarshipController(IStudentService service)
        {
           // _userManager = userManager;
            _service = service;
        }
        private string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value!;
        }

       
        [Authorize]
        [HttpGet("getAllRegistration")]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllStudentsAsync());

        [Authorize]
        [HttpGet("getRegistrationbyId/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var userId = GetUserId();
            var result = await _service.GetStudentByIdAsync(id, userId);
            if (result == null)
                return Forbid();


            return Ok(result);
        }

        [HttpPost("CreateRegistration")]
        public async Task<IActionResult> Create([FromBody] RegistrationDTO student)
        {
           

            // 2. Create domain Registration entity
            var registration = new Registration
            {
                FullName = student.FullName,
                Email = student.Email,
                PhoneNumber = student.PhoneNumber,
                Gender = student.Gender,
                DateOfBirth = student.DateOfBirth,
                Password = BCrypt.Net.BCrypt.HashPassword(student.Password),
                
            };

            await _service.AddStudentAsync(registration);

            return Ok(new { Message = "Registration successful" });
        }

      
        [HttpPut("UpdateRegistration")]
        public async Task<IActionResult> Update(int id, [FromBody] RegistrationDTO student)
        {
             await _service.UpdateStudentAsync(id, student, GetUserId());
            

            return Ok();
        }
       
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
             await _service.DeleteStudentAsync(id, GetUserId());

            return Ok();
        }
    }
}
