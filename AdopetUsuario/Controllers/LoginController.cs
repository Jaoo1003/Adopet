using AdopetUsuario.Data.Dtos;
using AdopetUsuario.Services;
using Microsoft.AspNetCore.Mvc;

namespace AdopetUsuario.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase{
        private LoginService _loginService;

        public LoginController(LoginService loginService) {
            _loginService = loginService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUsuarioDto dto) {
            var token = await _loginService.Login(dto);
            return Ok(token);
        }
    }
}