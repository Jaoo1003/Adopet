using Adopet___Alura_Challenge_6.Data.Dtos.Adocoes;
using Adopet___Alura_Challenge_6.Services;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Adopet___Alura_Challenge_6.Controller {
    [ApiController]
    [Route("[controller]")]
    public class AdocaoController : ControllerBase{
        private AdocaoService _service;
        public AdocaoController(AdocaoService service) {
            _service = service;
        }

        [HttpPost]
        public IActionResult CadastraAdocao([FromBody] CreateAdocaoDto dto) {
            var result = _service.CadastraAdocao(dto);
            return Ok(result);
        }

        [HttpGet]
        public IActionResult BuscaAdocoes() {
            var adocoes = _service.BuscaAdocoes();
            if (adocoes != null) return Ok(adocoes);
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult BuscaAdocoesPorId(int id) {
            var adocoes = _service.BuscaAdocoesPorId(id);
            if (adocoes != null) return Ok(adocoes);
            return NotFound();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Abrigo")]
        public IActionResult DeletaAdocao(int id) {
            Result result = _service.DeletaAdocao(id);
            if (result.IsSuccess) return StatusCode(204, "Sucesso ao deletar adoção");
            return NotFound("Não foi possivel deletar esta adoção");
        }
    }
}
