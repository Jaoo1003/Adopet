using Adopet___Alura_Challenge_6.Data.Dtos.Adocoes;
using Adopet___Alura_Challenge_6.Data.Ef_Core;
using Adopet___Alura_Challenge_6.Models;
using AutoMapper;
using FluentResults;
using Microsoft.EntityFrameworkCore;

namespace Adopet___Alura_Challenge_6.Services {
    public class AdocaoService {
        private AppDbContext _context;
        private IMapper _mapper;

        public AdocaoService(AppDbContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
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

        public IEnumerable<ReadAdocaoDto> BuscaAdocoes() {
            var adocoes = _context.Adocoes;
            if (adocoes != null) {
                return _mapper.Map<List<ReadAdocaoDto>>(adocoes);
            }
            return null;
        }

        public ReadAdocaoDto BuscaAdocoesPorId(int id) {
            var adocao = _context.Adocoes.FirstOrDefault(a => a.Id == id);
            if (adocao != null) {
                return _mapper.Map<ReadAdocaoDto>(adocao);
            }
            return null
        }
    }
}
