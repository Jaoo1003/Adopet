using AdopetUsuario.Data.Dtos;
using AdopetUsuario.Services;
using Microsoft.AspNetCore.Mvc;

namespace AdopetUsuario.Controllers {
    [ApiController]
    [Route("[Controller]")]
    public class UsuarioController : ControllerBase{
        private UsuarioService _usuarioService;
        public UsuarioController(UsuarioService cadastroService) {
            _usuarioService = cadastroService;
        }

        [HttpPost("tutor")]
        public async Task<IActionResult> CadastraUsuarioTutor(CreateUsuarioDto dto) {
            await _usuarioService.Cadastra(dto, "Tutor");
            return Ok("Usuário cadastrado");
        }

        [HttpPost("abrigo")]
        public async Task<IActionResult> CadastraUsuarioAbrigo(CreateUsuarioDto dto) {
            await _usuarioService.Cadastra(dto, "Abrigo");
            return Ok("Usuário cadastrado");
        }
    }
}