using Adopet___Alura_Challenge_6.Data.Dtos.Adocoes;
using Adopet___Alura_Challenge_6.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Adopet___Alura_Challenge_6.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class AdocaoController : ControllerBase{
        private readonly IAdminService _adminService;
        public AdocaoController(IAdminService adminService) {
            _adminService = adminService;
        }

        [HttpPost]
        public IActionResult CreateAdocao(AdocaoDto entity) {
            _adminService.CreateAdocao(entity);
            return NoContent();
        }

        [HttpGet("page/{skip:int}")]
        public IActionResult GetAllAdocoes(int skip) {
            var adocoes = _adminService.GetAllAdocoes(skip);
            return Ok(adocoes);
        }

        [HttpGet("{id}")]
        public IActionResult GetAdocaoById(int id) {
            var adocao = _adminService.GetAdocoById(id);
            return Ok(adocao);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAdocao(AdocaoDto entity, int id) {
            _adminService.UpdateAdocao(entity, id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Abrigo")]
        public IActionResult DeleteAdocaoById(int id) {
            _adminService.DeleteAdocao(id);
            return NoContent();
        }
    }
}
