using Adopet___Alura_Challenge_6.Data.Dtos.Abrigos;
using Adopet___Alura_Challenge_6.Data.InferfaceDao;
using Adopet___Alura_Challenge_6.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Adopet___Alura_Challenge_6.Data.Ef_Core {
    public class AbrigoDaoComEfCore : IAbrigoDao {

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AbrigoDaoComEfCore(AppDbContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public void Create(AbrigoDto entity) {
            Abrigo abrigo = _mapper.Map<Abrigo>(entity);
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id) {
            Abrigo abrigo = GetById(id);
            if(abrigo == null) {
                throw new ArgumentException("Abrigo Não Encontrado");
            }
            _context.Remove(abrigo);
            _context.SaveChanges();
        }

        public IEnumerable<Abrigo> GetAll() {
            return _context.Abrigos;
        }

        public Abrigo? GetById(int id) {
            return _context.Abrigos.Find(id);
        }

        public void Update(AbrigoDto entity, int id) {
            Abrigo abrigo = GetById(id);
            _mapper.Map(entity, abrigo);
            _context.SaveChanges();
        }
    }
}
