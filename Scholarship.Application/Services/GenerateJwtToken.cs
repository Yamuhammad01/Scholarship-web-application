using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Scholarship.Application.DTOs;
using Scholarship.Application.Interfaces;
using Scholarship.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Scholarship.Application.Services
{
    public class GenerateJwtToken 
    {
        private readonly IConfiguration _config;

        public GenerateJwtToken(IConfiguration configuration)
        {
            _config = configuration;
        }

        public string CreateToken(JwtPayloadDTO payload)
        {
            var claims = new[]
            {
              new Claim(JwtRegisteredClaimNames.Sub, payload.UserId.ToString()),
              new Claim(JwtRegisteredClaimNames.Email, payload.Email),
              
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["JwtSettings:Issuer"],
                audience: _config["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }



}

