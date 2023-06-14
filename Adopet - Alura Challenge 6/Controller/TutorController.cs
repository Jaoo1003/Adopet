using Adopet___Alura_Challenge_6.Data.Dtos.Abrigos;
using Adopet___Alura_Challenge_6.Data.Dtos.Tutors;
using Adopet___Alura_Challenge_6.Services;
using Adopet___Alura_Challenge_6.Services.Handler;
using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Adopet___Alura_Challenge_6.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class TutorController : ControllerBase{
        private readonly IAdminService _adminService;
        public TutorController(IAdminService adminService) {
            _adminService = adminService;
        }

        [HttpPost]
        public IActionResult CreateTutor(TutorDto entity) {
            _adminService.CreateTutor(entity);
            return NoContent();
        }

        [HttpGet]
        public IActionResult GetAllTutores() {
            var tutores = _adminService.GetAllTutor();
            return Ok(tutores);
        }

        [HttpGet]
        public IActionResult GetTutorById(int id) {
            var tutor = _adminService.GetTutorById(id);
            return Ok(tutor);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTutorById(TutorDto entity, int id) {
            _adminService.UpdateTutor(entity, id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTutorById(int id) {
            _adminService.DeleteTutor(id);
            return NoContent();
        }
    }
}