using Adopet___Alura_Challenge_6.Data.Dtos.Pets;
using Adopet___Alura_Challenge_6.Services;
using FluentResults;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Adopet___Alura_Challenge_6.Controller; 
[ApiController]
[Route("[controller]")]
public class PetController : ControllerBase{
    private PetService _service;
    public PetController(PetService service) {
        _service = service;
    }

    [HttpPost]
    public IActionResult AdicionaPet([FromBody] CreatePetDto dto) {
        if (!ModelState.IsValid) {
            return BadRequest(ModelState);
        }
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
        IEnumerable<ReadPetDto> pets = _service.BuscaPets();
        if (pets != null) return Ok(pets);
        return NotFound("Não encontrado");
    }

    [HttpPut("{id}")]
    public IActionResult AtualizaPets(int id, [FromBody]UpdatePetDto dto) {
        var result = _service.AtualizaPets(id, dto);
        if (result.IsSuccess) return NoContent();
        return NotFound(result);
    }

    [HttpPatch("{id}")]
    public IActionResult AtualizaPetsPatch(int id, JsonPatchDocument<UpdatePetDto> patch) {
        var pet = _service.BuscaPetPorIdReturnPet(id);
        var tutorToUpdate = _service.AtualizaPetsPatch(id, patch);
        patch.ApplyTo(tutorToUpdate, ModelState);

        if (!TryValidateModel(tutorToUpdate)){
            return ValidationProblem(ModelState);
        }

        Result result = _service.Atualiza(pet, tutorToUpdate);
        if (result.IsSuccess) return NoContent();
        return NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletaPetPorId(int id) {
        Result result = _service.DeletaPetPorId(id);
        if (result.IsSuccess) return NoContent();
        return NotFound("Não encontrado");
    }
}
