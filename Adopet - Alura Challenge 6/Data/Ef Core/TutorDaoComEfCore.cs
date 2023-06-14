using Adopet___Alura_Challenge_6.Data.Dtos.Tutors;
using Adopet___Alura_Challenge_6.Data.InferfaceDao;
using Adopet___Alura_Challenge_6.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;

namespace Adopet___Alura_Challenge_6.Data.Ef_Core {
    public class TutorDaoComEfCore : ITutorDao {

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public TutorDaoComEfCore(AppDbContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public void Create(TutorDto entity) {
            Tutor tutor = _mapper.Map<Tutor>(entity);
            _context.Add(tutor);
            _context.SaveChanges();
        }

        public void Delete(int id) {
            Tutor tutor = GetById(id);
            if (tutor == null) {
                throw new ArgumentException("Tutor Não Encontrado");
            }
            _context.Remove(tutor);
            _context.SaveChanges();
        }

        public IEnumerable<Tutor> GetAll() {
            return _context.Tutores;
        }

        public Tutor? GetById(int id) {
            return _context.Tutores.Find(id);
        }

        public void Update(TutorDto entity, int id) {
            Tutor tutor = GetById(id);
            _mapper.Map(entity, tutor);
            _context.SaveChanges();
        }

        public void UpdatePatch(int id, JsonPatchDocument<TutorDto> tutor) {
            throw new NotImplementedException();
        }
    }
}
