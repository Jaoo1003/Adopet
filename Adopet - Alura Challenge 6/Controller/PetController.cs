﻿using Adopet___Alura_Challenge_6.Data.Dtos.Abrigos;
using Adopet___Alura_Challenge_6.Data.Dtos.Pets;
using Adopet___Alura_Challenge_6.Models;
using Adopet___Alura_Challenge_6.Services;
using Adopet___Alura_Challenge_6.Services.Handler;
using FluentResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Adopet___Alura_Challenge_6.Controller;
[ApiController]
[Route("[controller]")]
public class PetController : ControllerBase{
    private readonly IAdminService _adminService;
    public PetController(IAdminService adminService) {
        _adminService = adminService;
    }

    [HttpPost]
    public IActionResult CreatePet(PetDto entity) {
        _adminService.CreatePet(entity);
        return NoContent();
    }

    [HttpGet]
    public IActionResult GetAllPets() {
        var pets = _adminService.GetAllPets();
        return Ok(pets);
    }

    [HttpGet]
    public IActionResult GetPetById(int id) {
        var pet = _adminService.GetPetById(id);
        return Ok(pet);
    }

    [HttpPut("{id}")]
    public IActionResult UpdatePetById(PetDto entity, int id) {
        _adminService.UpdatePet(entity, id);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeletePetById(int id) {
        _adminService.DeletePet(id);
        return NoContent();
    }
}
