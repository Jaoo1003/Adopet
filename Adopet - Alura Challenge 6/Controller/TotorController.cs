using Adopet___Alura_Challenge_6.Data.Dtos.Tutor;
using Adopet___Alura_Challenge_6.Data.Ef_Core;
using Adopet___Alura_Challenge_6.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace Adopet___Alura_Challenge_6.Controller {
    [ApiController]
    [Route("[controller]")]
    public class TotorController : ControllerBase{
        private AppDbContext _context;
        private IMapper _mapper;

        public TotorController(IMapper mapper, AppDbContext context) {
            _context = context;
            _mapper = mapper;
        }

        [HttpPatch("{id}")]
        public IActionResult AtualizaTutorPatch(int id, JsonPatchDocument<UpdateTutorDto> patch) {
            var tutor = _context.Tutores.FirstOrDefault(tutor => tutor.id == id);
            if (tutor == null) return NotFound();

            var tutorParaAtualizar = _mapper.Map<UpdateTutorDto>(tutor);
            patch.ApplyTo(tutorParaAtualizar, ModelState);

            if (!TryValidateModel(tutorParaAtualizar)) {
                return ValidationProblem(ModelState);
            }

            _mapper.Map<Tutor>(tutorParaAtualizar);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaTutorPatch(int id, [FromBody] UpdateTutorDto dto) {
            var tutor = _context.Tutores.FirstOrDefault(tutor => tutor.id == id);
            if (tutor == null) return NotFound();

            _mapper.Map(dto, tutor);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpPost]
        public IActionResult CadastrarTutor([FromBody] CreateTutorDto dto) {
            var tutor = _mapper.Map<Tutor>(dto);
            _context.Tutores.Add(tutor);
            _context.SaveChanges();
            return CreatedAtAction(nameof(BuscaTutorPorId), new { id = tutor.Id }, tutor);
        }

        [HttpGet]
        public IEnumerable<Tutor> BuscarTutores() {
            return _context.Tutores;
        }

        [HttpGet("{id}")]
        public IActionResult BuscaTutorPorId(int id) {
            var tutor = _context.Tutores.FirstOrDefault(tutor => tutor.Id == id);
            if (tutor == null) return NotFound();

            return Ok(tutor);
        }
    }
}