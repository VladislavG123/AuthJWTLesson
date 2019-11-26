using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthJWTLesson.DTO;
using AuthJWTLesson.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthJWTLesson.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService authService;

        public AuthController(AuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> Auth(AuthDTO authDTO)
        {
            /*
             1. принимаем в параметрах объект с данными пользователя (DTO)
             2. обращаемся к сервису который проводит аутендификацию
             3. получаем от сервиса токен 
                а) если токин пуст - кидаем 401
                б) если всё ок возвращаем токен в объекте
             */

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var token = await authService.Authenticate(authDTO.Username, authDTO.Password);

            if (String.IsNullOrEmpty(token))
            {
                return Unauthorized();
            }

            return Ok(new { token });
        }
    }
}