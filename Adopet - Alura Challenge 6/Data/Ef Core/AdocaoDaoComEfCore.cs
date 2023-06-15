using Adopet___Alura_Challenge_6.Data.Dtos.Adocoes;
using Adopet___Alura_Challenge_6.Data.InferfaceDao;
using Adopet___Alura_Challenge_6.Models;
using AutoMapper;

namespace Adopet___Alura_Challenge_6.Data.Ef_Core {
    public class AdocaoDaoComEfCore : IAdocaoDao {

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public AdocaoDaoComEfCore(AppDbContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public void Create(AdocaoDto entity) {

            if (!VerifyIfTutorAndPetExists(entity.TutorId, entity.PetId)) {
                throw new ArgumentException("tutor e/ou pet inexistentes");
            }
            Adocao adocao = _mapper.Map<Adocao>(entity);
            _context.Add(adocao);
            _context.SaveChanges();            
        }

        public void Delete(int id) {
            Adocao adocao = GetById(id);
            if(adocao == null) {
                throw new ArgumentException("Adoção Não Encontrada");
            }
            _context.Remove(adocao);
        }

        public IEnumerable<Adocao> GetAll() {
            return _context.Adocoes;
        }

        public Adocao? GetById(int id) {
            return _context.Adocoes.Find(id);
        }

        public void Update(AdocaoDto entity, int id) {
            Adocao adocao = GetById(id);
            _mapper.Map(entity, adocao);
            _context.SaveChanges();
        }

        public bool VerifyIfTutorAndPetExists(int? tutorId, int? petId) {
            var tutor = _context.Tutores.Find(tutorId);
            var pet = _context.Pets.Find(petId);
            if(tutor != null && pet != null) return true;

            return false;
        }
    }
}
