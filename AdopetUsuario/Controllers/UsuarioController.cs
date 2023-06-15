using Adopet.Usuario.Services;
using AdopetUsuario.Data.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace AdopetUsuario.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class UsuarioController : ControllerBase{
        private readonly IAdminUserService _adminUserService;
        public UsuarioController(IAdminUserService adminUserService) {
            _adminUserService = adminUserService;
        }

        [HttpPost("abrigo")]
        public async Task<IActionResult >CadastraUsuarioAbrigo(CreateUsuarioDto dto) {
            await _adminUserService.Cadastra(dto, "abrigo");
            return Ok("Usuario cadastrado");
        }

        [HttpPost("tutor")]
        public async Task<IActionResult> CadastraUsuarioTutor(CreateUsuarioDto dto) {
            await _adminUserService.Cadastra(dto, "tutor");
            return Ok("Usuario cadastrado");
        }
    }
}