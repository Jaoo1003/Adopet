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

        [HttpPost]
        public async Task<IActionResult> CadastraUsuario(CreateUsuarioDto dto) {
            await _usuarioService.Cadastra(dto);
            return Ok("Usuário cadastrado");
        }
    }
}