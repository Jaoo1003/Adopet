using Adopet___Alura_Challenge_6.Data.Dtos.Tutors;
using Adopet___Alura_Challenge_6.Data.InferfaceDao;
using Adopet___Alura_Challenge_6.Models;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc.Razor.TagHelpers;

namespace Adopet___Alura_Challenge_6.Data.Ef_Core {
    public class TutorDaoComEfCore : ITutorDao {

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public TutorDaoComEfCore(AppDbContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public bool Create(TutorDto entity) {
            ValidateTutorDtoFields(entity);
            Tutor tutor = _mapper.Map<Tutor>(entity);
            _context.Add(tutor);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id) {
            Tutor tutor = GetById(id);
            _context.Remove(tutor);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<Tutor> GetAll() {
            return _context.Tutores.ToList();
        }

        public Tutor? GetById(int id) {
            var tutor = _context.Tutores.Find(id);
            if (tutor == null) {
                throw new ArgumentException("Tutor Não Encontrado");
            }
            return tutor;
        }

        public bool Update(TutorDto entity, int id) {
            ValidateTutorDtoFields(entity);
            Tutor tutor = GetById(id);
            _mapper.Map(entity, tutor);
            _context.SaveChanges();
            return true;
        }

        public bool UpdatePatch(int id, JsonPatchDocument<TutorDto> tutor) {
            return true;
        }

        public void ValidateTutorDtoFields(TutorDto dto) {
            if (!TryValidateTutorDtoModelState(dto)) {
                throw new ArgumentException("Verifique se todos os campos foram preenchidos corretamente");
            }
            if (!VerifyIfPasswordAndRePasswordAreEqual(dto)) {
                throw new ArgumentException("Verifique se a senha e a confirmação da senha são iguais");
            }
        }

        private bool TryValidateTutorDtoModelState(TutorDto tutorDto) {
            if (string.IsNullOrEmpty(tutorDto.Nome) || string.IsNullOrEmpty(tutorDto.Email) || string.IsNullOrEmpty(tutorDto.Password) || string.IsNullOrEmpty(tutorDto.RePassword)) {
                return false;
            }
            return true;
        }

        private bool VerifyIfPasswordAndRePasswordAreEqual(TutorDto dto) {
            if (!string.Equals(dto.Password, dto.RePassword)) {
                return false;
            }
            return true;
        }
    }
}
