using Adopet___Alura_Challenge_6.Data.Dtos.Pets;
using Adopet___Alura_Challenge_6.Data.Ef_Core;
using Adopet___Alura_Challenge_6.Models;
using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.JsonPatch;

namespace Adopet___Alura_Challenge_6.Services {
    public class PetService {

        private AppDbContext _context;
        private IMapper _mapper;

        public PetService(AppDbContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public ReadPetDto AdicionaPet(CreatePetDto dto) {
            var pet = _mapper.Map<Pet>(dto);
            _context.Add(pet);
            _context.SaveChanges();

            return _mapper.Map<ReadPetDto>(pet);
        }

        public ReadPetDto BuscaPetPorId(int id) {
            var pet = _context.Pets.FirstOrDefault(pet => pet.Id == id);
            if (pet != null) {
                return _mapper.Map<ReadPetDto>(pet);
            }
            return null;
        }

        public Pet BuscaPetPorIdReturnPet(int id) {
            var pet = _context.Pets.FirstOrDefault(pet => pet.Id == id);
            if (pet != null) {
                return pet;
            }
            return null;
        }

        public List<ReadPetDto> BuscaPets() {
            List<Pet> pets = _context.Pets.ToList();
            if (pets != null) return _mapper.Map<List<ReadPetDto>>(pets);
            return null;
        }

        public Result AtualizaPets(int id, UpdatePetDto dto) {
            var pet = _context.Pets.FirstOrDefault(pet => pet.Id == id);
            if(pet == null) {
                return Result.Fail("Não encontrado");
            }

            _mapper.Map(dto, pet);
            _context.SaveChanges();
            return Result.Ok();
        }

        public UpdatePetDto AtualizaPetsPatch(int id, JsonPatchDocument<UpdatePetDto> patch) {
            var pet = _context.Pets.FirstOrDefault(pet => pet.Id == id);
            if (pet == null) return null;
            return _mapper.Map<UpdatePetDto>(pet);
        }

        public Result Atualiza(Pet pet, UpdatePetDto tutorToUpdate) {
            _mapper.Map(tutorToUpdate, pet);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletaPetPorId(int id) {
            var pet = _context.Pets.FirstOrDefault(pet => pet.Id == id);
            if (pet == null) return Result.Fail("");

            _context.Remove(pet);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
