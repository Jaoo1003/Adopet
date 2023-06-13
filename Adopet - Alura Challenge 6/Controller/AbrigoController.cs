using Adopet___Alura_Challenge_6.Data.Dtos.Abrigos;
using Adopet___Alura_Challenge_6.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace Adopet___Alura_Challenge_6.Controller {
    [ApiController]
    [Route("[controller]")]
    public class AbrigoController : ControllerBase{
        private AbrigoService _service;
        public AbrigoController(AbrigoService service) {
            _service = service;
        }

        [HttpGet]
        public IActionResult BuscaAbrigos() {
            List<ReadAbrigoDto> abrigos = _service.BuscaAbrigos();
            if (abrigos != null) return Ok(abrigos);
            return NotFound("Não encontrado");
        }

        [HttpGet("{id}")]
        public IActionResult BuscaAbrigosPorId(int id) {
            var abrigo = _service.BuscaAbrigoPorId(id);
            if (abrigo != null) return Ok(abrigo);
            return NotFound("Não encontrados");
        }

        [HttpPost]
        public IActionResult CadastraAbrigo([FromBody] CreateAbrigoDto dto) {
            ReadAbrigoDto readDto = _service.CadastraAbrigo(dto);
            return CreatedAtAction(nameof(BuscaAbrigosPorId), new { id = readDto.Id }, readDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaAbrigo(int id, [FromBody] UpdateAbrigoDto dto) {
            Result resultado = _service.AtualizaAbrigo(id, dto);
            if (resultado.IsSuccess) return NoContent();
            return NotFound(resultado);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaAbrigo(int id) {
            Result resultado = _service.DeletaAbrigo(id);
            if(resultado.IsSuccess) return NoContent();
            return NotFound(resultado);
        }        
    }
}