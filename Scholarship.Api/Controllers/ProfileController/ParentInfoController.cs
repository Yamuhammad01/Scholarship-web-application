using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Scholarship.Application.DTOs;
using Scholarship.Application.DTOs.ParentInfoDTO;
using Scholarship.Application.Interfaces;
using Scholarship.Application.Services;
using Scholarship.Domain.Entities.ParentInfo;

namespace Scholarship.Api.Controllers.ProfileController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParentInfoController : ControllerBase
    {
        private readonly ParentInfoService _parentInfoService;
        public ParentInfoController(ParentInfoService parentInfoService)
        {
            _parentInfoService = parentInfoService;
        }
        [HttpPost("AddFathersInformation")]
        public async Task<IActionResult> AddFathersInformation([FromBody] FathersDTO fathersDTO)
        {

            await _parentInfoService.AddFathersInfoAsync(fathersDTO);

            return Ok(new { Message = "Success" });
        }
        [HttpGet("GetFathersInfoById/{id}")]
        public async Task<IActionResult> GetFathersInfoById(int id)
        {

            var result = await _parentInfoService.GetFathersInfoByIdAsync(id);
            if (result == null)
                return Forbid();


            return Ok(result);
        }
        [HttpPut("UpdateFathersInformation/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] FathersDTO fathersDTO)
        {
            await _parentInfoService.UpdateFathersInfoAsync(id, fathersDTO);
            return NoContent();
        }
        [HttpPost("AddMothersInformation")]
        public async Task<IActionResult> AddMothersInformation([FromBody] MothersDTO mothersDTO)
        {

            await _parentInfoService.AddMothersInfoAsync(mothersDTO);

            return Ok(new { Message = "Success" });
        }
        [HttpPut("UpdateMothersInformation/{id}")]
        public async Task<IActionResult> UpdateMothersInformation(int id, [FromBody] MothersDTO mothersDTO)
        {
            await _parentInfoService.UpdateMothersInfoAsync(id, mothersDTO);
            return NoContent();
        }
        [HttpPost("AddNextOfKinInformation")]
        public async Task<IActionResult> NextOfKinInformation([FromBody] NextOfKinDTO nextOfKinDTO)
        {

            await _parentInfoService.AddNextOfKinInfoAsync(nextOfKinDTO);

            return Ok(new { Message = "Success" });
        }
        [HttpPut("UpdateNextOfKinInformation/{id}")]
        public async Task<IActionResult> UpdateNextOfKinInformation(int id, [FromBody] NextOfKinDTO nextOfKinDTO)
        {
            await _parentInfoService.UpdateNextOfKinInfoAsync(id, nextOfKinDTO);
            return NoContent();
        }

    }
   
}
