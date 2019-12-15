using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthJWTLesson.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthJWTLesson.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HomeController : ControllerBase
    {
        private readonly AuthService authService;

        public HomeController(AuthService authService)
        {
            this.authService = authService;
        }

        [HttpGet]
        public IActionResult GetSecoreInfo(string token)
        {
           var data = authService.DecryptToken(token);

            return Ok(new { data });
        }
    }
}