using Adopet___Alura_Challenge_6.Data.Dtos.Pets;
using Adopet___Alura_Challenge_6.Data.InferfaceDao;
using Adopet___Alura_Challenge_6.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;

namespace Adopet___Alura_Challenge_6.Data.Ef_Core {
    public class PetDaoComEfCore : IPetDao {

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public PetDaoComEfCore(AppDbContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public void Create(PetDto entity) {
            Pet pet = _mapper.Map<Pet>(entity);
            _context.Add(pet);
            _context.SaveChanges();
        }

        public void Delete(int id) {
            Pet pet = GetById(id);
            if (pet == null) {
                throw new ArgumentException("Pet Não Encontrado");
            }
        }

        public IEnumerable<Pet> GetAll() {
            return _context.Pets;
        }

        public Pet GetById(int id) {
            return _context.Pets.Find(id);
        }

        public void Update(PetDto entity, int id) {
            Pet pet = GetById(id);
            _mapper.Map(entity, pet);
            _context.SaveChanges();
        }

        public void UpdatePatch(int id, JsonPatchDocument<PetDto> pet) {
            throw new NotImplementedException();
        }
    }
}
