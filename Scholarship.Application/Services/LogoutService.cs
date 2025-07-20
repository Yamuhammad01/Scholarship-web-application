using Microsoft.AspNetCore.Http;
using Scholarship.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scholarship.Application.Services
{
    public class LogoutService : ILogoutService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public LogoutService(IHttpContextAccessor httpContextAccessor) 
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public void Logout()
        {
            // If using JWT, log out by invalidating the token (session handling).
            // This can be done by removing the authentication cookies, tokens, or any session data.
            _httpContextAccessor.HttpContext.Response.Cookies.Delete("jwtToken");
        }
    }
}
