using Adopet___Alura_Challenge_6.Data.Dtos.Abrigos;
using Adopet___Alura_Challenge_6.Data.Dtos.Adocoes;
using Adopet___Alura_Challenge_6.Data.Ef_Core;
using Adopet___Alura_Challenge_6.Models;
using AutoMapper;
using FluentResults;

namespace Adopet___Alura_Challenge_6.Services {
    public class AbrigoService {
        private AppDbContext _context;
        private IMapper _mapper;
        public AbrigoService(AppDbContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public List<ReadAbrigoDto>? BuscaAbrigos() {
            List<Abrigo> abrigos = _context.Abrigos.ToList();

            if (abrigos != null) {
                return _mapper.Map<List<ReadAbrigoDto>>(abrigos);
            }
            return null;
        }

        public ReadAbrigoDto? BuscaAbrigoPorId(int id) {
            var abrigo = _context.Abrigos.FirstOrDefault(abrigo => abrigo.Id == id);
            if (abrigo != null) {
                var dto = _mapper.Map<ReadAbrigoDto>(abrigo);
                return dto;
            }
            return null;
        }

        public ReadAbrigoDto CadastraAbrigo(CreateAbrigoDto dto) {
            var abrigo = _mapper.Map<Abrigo>(dto);
            _context.Add(abrigo);
            _context.SaveChanges();

            return _mapper.Map<ReadAbrigoDto>(abrigo);
        }

        public Result AtualizaAbrigo(int id, UpdateAbrigoDto dto) {
            var abrigo = _context.Abrigos.FirstOrDefault(abrigo => abrigo.Id == id);
            if (abrigo == null) {
                return Result.Fail("não encontrado");
            }
            _mapper.Map(dto, abrigo);
            _context.SaveChanges();
            return Result.Ok();
        }

        public Result DeletaAbrigo(int id) {
            var abrigo = _context.Abrigos.FirstOrDefault(abrigo => abrigo.Id == id);
            if (abrigo == null) return Result.Fail("Não encontrado");

            _context.Remove(abrigo);
            _context.SaveChanges();
            return Result.Ok();
        }        
    }
}