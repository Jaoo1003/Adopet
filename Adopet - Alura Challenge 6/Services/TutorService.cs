using Adopet___Alura_Challenge_6.Data.Dtos.Tutors;
using Adopet___Alura_Challenge_6.Data.Ef_Core;
using Adopet___Alura_Challenge_6.Models;
using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.JsonPatch;

namespace Adopet___Alura_Challenge_6.Services {
    public class TutorService {
        private AppDbContext _context;
        private IMapper _mapper;

        public TutorService(AppDbContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public UpdateTutorDto? AtualizaTutorPatch(int id, JsonPatchDocument<UpdateTutorDto> patch) {
            var tutor = _context.Tutores.FirstOrDefault(tutor => tutor.Id == id);
            if (tutor == null) return null;

            return _mapper.Map<UpdateTutorDto>(tutor);
        }

        public Result Atualiza(object? tutor, object tutorParaAtualizar) {
            _mapper.Map(tutorParaAtualizar, tutor);
            _context.SaveChanges();
            return Result.Ok();
        }

        public ReadTutorDto? BuscaTutorPorId(int id) {
            var tutor = _context.Tutores.FirstOrDefault(tutor => tutor.Id == id);
            if (tutor != null) {
                return _mapper.Map<ReadTutorDto>(tutor);
            }
            return null;
        }

        public Result AtualizaTutorPut(int id, UpdateTutorDto dto) {
            var tutor = _context.Tutores.FirstOrDefault(tutor => tutor.Id == id);
            if (tutor == null) return Result.Fail("Não encontrado");

            Atualiza(dto, tutor);
            return Result.Ok();
        }

        public ReadTutorDto CadastraTutor(CreateTutorDto dto) {
            var tutor = _mapper.Map<Tutor>(dto);
            _context.Add(tutor);
            _context.SaveChanges();

            return _mapper.Map<ReadTutorDto>(tutor);
        }

        public IEnumerable<ReadTutorDto>? BuscaTutores() {
            var tutores = _context.Tutores.ToList();
            if (tutores != null) {
                return _mapper.Map<List<ReadTutorDto>>(tutores);
            }
            return null;
        }

        public Result DeletaTutor(int id) {
            var tutor = _context.Tutores.FirstOrDefault(tutor => tutor.Id == id);
            if (tutor == null) return Result.Fail("Não encontrado");

            _context.Remove(tutor);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}