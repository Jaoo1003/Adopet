using Adopet___Alura_Challenge_6.Data.Dtos.Tutors;
using Adopet___Alura_Challenge_6.Data.Ef_Core;
using Adopet___Alura_Challenge_6.Models;
using Adopet___Alura_Challenge_6.Services;
using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Adopet___Alura_Challenge_6.Controller {
    [ApiController]
    [Route("[controller]")]
    public class TutorController : ControllerBase{
        private TutorService _service;

        public TutorController(TutorService service) {
            _service = service;
        }

        [HttpPatch("{id}")]
        public IActionResult AtualizaTutorPatch(int id, JsonPatchDocument<UpdateTutorDto> patch) {
            var tutor = _service.BuscaTutorPorId(id);
            var tutorParaAtualizar = _service.AtualizaTutorPatch(id, patch);
            patch.ApplyTo(tutorParaAtualizar, ModelState);

            if (!TryValidateModel(tutorParaAtualizar)) {
                return ValidationProblem(ModelState);
            }

            var salvar = _service.Atualiza(tutor, tutorParaAtualizar);
            if (salvar.IsSuccess) return NoContent();
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaTutorPut(int id, [FromBody] UpdateTutorDto dto) {
            Result result = _service.AtualizaTutorPut(id, dto);
            if(result.IsSuccess) return NoContent();
            return NotFound();
        }

        [HttpPost]
        public IActionResult CadastrarTutor([FromBody] CreateTutorDto dto) {
            var tutor = _service.CadastraTutor(dto);
            return CreatedAtAction(nameof(BuscaTutorPorId), new { id = tutor.Id }, tutor);
        }

        [HttpGet]
        public IActionResult BuscarTutores() {
            var tutores = _service.BuscaTutores();
            if (tutores != null) return Ok(tutores);
            return NotFound();

        }

        [HttpGet("{id}")]
        public IActionResult BuscaTutorPorId(int id) {
            var tutor = _service.BuscaTutorPorId(id);
            if (tutor != null) return Ok(tutor);
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaTutor(int id) {
            var tutor = _service.DeletaTutor(id);
            if (tutor.IsSuccess) return NoContent();
            return NotFound();
        }
    }
}