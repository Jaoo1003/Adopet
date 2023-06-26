using Adopet___Alura_Challenge_6.Data.Dtos.Pets;
using Adopet___Alura_Challenge_6.Data.InferfaceDao;
using Adopet___Alura_Challenge_6.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Adopet___Alura_Challenge_6.Data.Ef_Core {
    public class PetDaoComEfCore : IPetDao {

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public PetDaoComEfCore(AppDbContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public bool Create(PetDto entity) {
            if (!TryValidatePetDtoModelState(entity)) {
                throw new ArgumentException("Verifique se todos os campos foram preenchidos corretamente!");
            }
            Pet pet = _mapper.Map<Pet>(entity);
            _context.Add(pet);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id) {
            Pet pet = GetById(id);
            _context.Remove(pet);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<Pet> GetAll() {
            return _context.Pets.ToList();
        }

        public Pet GetById(int id) {
            var pet = _context.Pets.Find(id);

            if (pet == null) {
                throw new ArgumentException("Pet Não Encontrado");
            }

            return pet;
        }

        public bool Update(PetDto entity, int id) {
            if (!TryValidatePetDtoModelState(entity)) {
                throw new ArgumentException("Certifique-se de que todos os campos foram preenchidos corretamente");
            }
            Pet pet = GetById(id);
            _mapper.Map(entity, pet);
            _context.SaveChanges();
            return true;
        }

        public bool UpdatePatch(int id, JsonPatchDocument<PetDto> pet) {
            return true;
        }

        public bool TryValidatePetDtoModelState(PetDto petDto) {
            if (petDto.AbrigoId == null ||
                string.IsNullOrEmpty(petDto.Nome) ||
                petDto.Idade == null ||
                string.IsNullOrEmpty(petDto.Porte) ||
                string.IsNullOrEmpty(petDto.Personalidade) ||
                petDto.Adotado == true ||
                string.IsNullOrEmpty(petDto.Endereco)) {
                return false;
            }
            return true;
        }
    }
}