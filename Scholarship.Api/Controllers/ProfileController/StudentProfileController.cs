using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Scholarship.Application.DTOs;
using Scholarship.Application.Interfaces;
using Scholarship.Domain.Entities;

namespace Scholarship.Api.Controllers.ProfileController
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentProfileController : Controller
    {
        private readonly IProfileService _profileService;
        public StudentProfileController(IProfileService profileService)
        {
            _profileService = profileService;
        }
        [HttpPost("Createbiodata")]
        public async Task<IActionResult> AddBiodata([FromBody] BiodataDTO biodata)
        {

            await _profileService.AddStudentBiodataAsync(biodata);

            return Ok(new { Message = "Biodata Created Successfully" });
        }
        [HttpPut("UpdateBiodata/{id}")]
        public async Task<IActionResult> UpdateBiodata(int id, [FromBody] BiodataDTO dto)
        {
            await _profileService.UpdateBiodataAsync(id, dto);
            return NoContent();
        }

        [HttpGet("getBiodatabyId/{id}")]
        public async Task<IActionResult> GetBiodataById(int id)
        {

            var result = await _profileService.GetBiodataaByIdAsync(id);
            if (result == null)
                return Forbid();


            return Ok(result);
        }

        //Academic Information Controller

        [HttpPost("AddAcademicInformation")]
        public async Task<IActionResult> AddAcademicInformation([FromBody] AcademicLevelDTO academicLevelDTO)
        {

            await _profileService.AddAcademicInfoAsync(academicLevelDTO);

            return Ok(new { Message = "Academic Information added Successfully" });
        }
        [HttpPut("UpdateAcademicInformation/{id}")]
        public async Task<IActionResult> UpdateAcademicInformation(int id, [FromBody] AcademicLevelDTO academicLevelDTO)
        {
            await _profileService.UpdateAcademicInfoAsync(id, academicLevelDTO);
            return NoContent();
        }
    }
}
