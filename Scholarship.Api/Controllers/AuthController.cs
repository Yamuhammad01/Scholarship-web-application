using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Scholarship.Application.Interfaces;
using Scholarship.Application.DTOs;
using Scholarship.Application.Services;
using Scholarship.Infrastructure.Persistence;
using Scholarship.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Graph;
using Microsoft.Graph.Models;
using Scholarship.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Jose;
using Microsoft.IdentityModel.Tokens;
using BCrypt.Net;

namespace Scholarship.Api.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
       // private readonly IAuthService _authService;
        //private readonly ApplicationDbContext _context;
        private readonly ProfileService _profileService;
        private readonly GenerateJwtToken _jwtTokenGenerator;
        // private readonly UserManager<IdentityUser> _userManager;
        //private readonly SignInManager<IdentityUser> _signInManager;
        
        //private string userName;

        public AuthController(ProfileService profileService, GenerateJwtToken generateJwtToken)
        {
           
            //_authService1 = authService;
           // _context = context;
            // _userManager = userManager;
            // _signInManager = signInManager;
          
            _jwtTokenGenerator = generateJwtToken;
            _profileService = profileService;
        }

        //public object s { get; private set; }

        // [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDto)
        {
            // Step 1: Fetch user from DB using username or email
            var userInfoFromDb = await _profileService.GetUserByEmailAsync(loginDto.Email);

            if (userInfoFromDb == null)
                return Unauthorized(new { message = "Invalid Email" });

            // Step 2: Validate password (this should ideally be hashed comparison)
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(loginDto.Password, userInfoFromDb.Password);

            if (!isPasswordValid)
                return Unauthorized(new { message = "Invalid Password" });

            // Step 3: Generate JWT
            var token = _jwtTokenGenerator.CreateToken(new JwtPayloadDTO
            {
                UserId = userInfoFromDb.Id,
                Email = userInfoFromDb.Email
               
            });

            return Ok(new
            {
                token,
                user = new
                {
                    userInfoFromDb.Id,
                    userInfoFromDb.Email
                }
            });
        }

    }
}
