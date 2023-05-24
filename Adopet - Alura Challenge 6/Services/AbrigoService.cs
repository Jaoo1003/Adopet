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

        public List<ReadAbrigoDto> BuscaAbrigos() {
            List<Abrigo> abrigos = _context.Abrigos.ToList();

            if (abrigos != null) {
                return _mapper.Map<List<ReadAbrigoDto>>(abrigos);
            }
            return null;
        }

        public ReadAbrigoDto BuscaAbrigoPorId(int id) {
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

        public ReadAdocaoDto CadastraAdocao(CreateAdocaoDto dto) {
            var adocao = _mapper.Map<Adocao>(dto);
            _context.Add(adocao);

            var pet = _context.Pets.Where(pet => pet.Id == dto.PetId).First();
            pet.Adotado = true;

            _context.SaveChanges();

            return _mapper.Map<ReadAdocaoDto>(adocao);
        }

        public Result DeletaAdocao(int id) {
            var adocao = _context.Adocoes.FirstOrDefault(adocao => adocao.Id == id);
            if (adocao == null) return Result.Fail("Não encontrado");

            _context.Remove(adocao);

            Pet pet = _context.Pets.Where(pet => pet.Id == adocao.PetId).First();
            pet.Adotado = false;

            _context.SaveChanges();
            return Result.Ok();
        }
    }
}