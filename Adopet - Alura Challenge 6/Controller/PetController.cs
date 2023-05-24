using Adopet___Alura_Challenge_6.Data.Dtos.Pets;
using Adopet___Alura_Challenge_6.Data.Ef_Core;
using Adopet___Alura_Challenge_6.Models;
using Adopet___Alura_Challenge_6.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Adopet___Alura_Challenge_6.Controller {
    [ApiController]
    [Route("[controller]")]
    public class PetController : ControllerBase{
        private PetService _service;
        public PetController(PetService service) {
            _service = service;
        }

        [HttpPost]
        public IActionResult AdicionaPet([FromBody] CreatePetDto dto) {
            ReadPetDto pet = _service.AdicionaPet(dto);
            return CreatedAtAction(nameof(BuscaPetPorId), new { id = pet.Id }, pet);
        }

        [HttpGet("{id}")]
        public IActionResult BuscaPetPorId(int id) {
            ReadPetDto pet = _service.BuscaPetPorId(id);
            if (pet != null) return Ok(pet);
            return NotFound("Não encontrado");
        }

        [HttpGet]
        public IActionResult BuscaPets() {
            ICollection<ReadPetDto> pets = _service.BuscaPets();
            if (pets != null) return Ok(pets);
            return NotFound("Não encontrado");
        }
    }
}
