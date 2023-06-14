using Adopet___Alura_Challenge_6.Data.Dtos.Abrigos;
using Adopet___Alura_Challenge_6.Data.Dtos.Adocoes;
using Adopet___Alura_Challenge_6.Services;
using Adopet___Alura_Challenge_6.Services.Handler;
using FluentResults;
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

        [HttpGet]
        public IActionResult GetAllAdocoes() {
            var adocoes = _adminService.GetAllAdocoes();
            return Ok(adocoes);
        }

        [HttpGet]
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
