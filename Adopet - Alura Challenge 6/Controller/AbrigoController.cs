using Adopet___Alura_Challenge_6.Data.Dtos.Abrigos;
using Adopet___Alura_Challenge_6.Services;
using Microsoft.AspNetCore.Mvc;

namespace Adopet___Alura_Challenge_6.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class AbrigoController : ControllerBase {
        private readonly IAdminService _adminService;
        public AbrigoController(IAdminService adminService) {
            _adminService = adminService;
        }

        [HttpPost]
        public IActionResult CreateAbrigo(AbrigoDto entity) {
            _adminService.CreateAbrigo(entity);
            return NoContent();
        }

        [HttpGet("page/{skip:int}")]
        public IActionResult GetAllAbrigos([FromRoute] int skip) {
            var abrigos = _adminService.GetAllAbrigos(skip);
            return Ok(abrigos);
        }

        [HttpGet("{id}")]
        public IActionResult GetAbrigoById(int id) {
            var abrigo = _adminService.GetAbrigoById(id);
            return Ok(abrigo);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAbrigoById(AbrigoDto entity, int id) {
            _adminService.UpdateAbrigo(entity, id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAbrigoById(int id) {
            _adminService.DeleteAbrigo(id);
            return NoContent();
        }
    }
}