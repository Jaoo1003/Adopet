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

        public bool Create(AdocaoDto entity) {

            if (!VerifyIfTutorAndPetExists(entity.TutorId, entity.PetId)) {
                throw new ArgumentException("tutor e/ou pet inexistentes");
            }
            Adocao adocao = _mapper.Map<Adocao>(entity);
            _context.Add(adocao);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id) {
            Adocao adocao = GetById(id);
            _context.Remove(adocao);
            return true;
        }

        public IEnumerable<Adocao> GetAll(int skip) {
            return _context.Adocoes.Skip(skip * 10).Take(10);
        }

        public Adocao? GetById(int id) {
            var adocao =  _context.Adocoes.Find(id);
            if (adocao == null) {
                throw new ArgumentException("Adoção Não Encontrada");
            }

            return adocao;
        }

        public bool Update(AdocaoDto entity, int id) {
            if (!TryValidateAdocaoDtoModelState(entity)) {
                throw new ArgumentException("Verifique se os campos PetId e TutorId foram preenchidos corretamente");
            }
            Adocao adocao = GetById(id);
            
            _mapper.Map(entity, adocao);
            _context.SaveChanges();
            return true;
        }

        public bool VerifyIfTutorAndPetExists(int? tutorId, int? petId) {
            var tutor = _context.Tutores.Find(tutorId);
            var pet = _context.Pets.Find(petId);
            if(tutor != null && pet != null) return true;

            return false;
        }

        public bool TryValidateAdocaoDtoModelState(AdocaoDto entity) {
            if (entity.TutorId == null || entity.PetId == null) {
                return false;
            }
            return true;
        }
    }
}
