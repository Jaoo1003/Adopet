using Adopet___Alura_Challenge_6.Data.Dtos.Pets;
using Adopet___Alura_Challenge_6.Data.Ef_Core;
using Adopet___Alura_Challenge_6.Models;
using AutoMapper;

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

        public List<ReadPetDto> BuscaPets() {
            List<Pet> pets = _context.Pets.ToList();
            if (pets != null) return _mapper.Map<List<ReadPetDto>>(pets);
            return null;
        }
    }
}
