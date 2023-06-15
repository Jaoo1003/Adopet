using Adopet.Usuario.Services;
using AdopetUsuario.Data.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace AdopetUsuario.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase{
        private readonly IAdminUserService _adminUserService;

        public LoginController(IAdminUserService adminUserService) {
            _adminUserService = adminUserService;
        }

        [HttpPost]
        public async Task<ObjectResult> Login(LoginUsuarioDto dto) {
            var token = await _adminUserService.Login(dto);
            return token;            
        }
    }
}