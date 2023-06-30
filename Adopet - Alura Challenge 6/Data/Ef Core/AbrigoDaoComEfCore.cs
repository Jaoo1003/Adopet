using Adopet___Alura_Challenge_6.Data.Dtos.Abrigos;
using Adopet___Alura_Challenge_6.Data.InferfaceDao;
using Adopet___Alura_Challenge_6.Models;
using AutoMapper;
using Castle.Core.Internal;

namespace Adopet___Alura_Challenge_6.Data.Ef_Core {
    public class AbrigoDaoComEfCore : IAbrigoDao {

        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AbrigoDaoComEfCore(AppDbContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public bool Create(AbrigoDto entity) {

            if (!ValidateObjectModelStateForTests(entity)) {
                throw new ArgumentException("Abrigo não Criado! Verifique se todos os campos foram preenchidos corretamente");
            }

            Abrigo abrigo = _mapper.Map<Abrigo>(entity);
            _context.Add(abrigo);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id) {
            Abrigo abrigo = GetById(id);
            _context.Remove(abrigo);
            _context.SaveChanges();
            return true;
        }

        public IEnumerable<Abrigo> GetAll(int skip) {
            var datas = _context.Abrigos.Skip(skip * 10).Take(10);
            return datas;
        }

        public Abrigo? GetById(int id) {
            var abrigo = _context.Abrigos.Find(id);
            if (abrigo == null) {
                throw new ArgumentException("Abrigo Não Encontrado");
            }

            return abrigo;
        }

        public bool Update(AbrigoDto entity, int id) {
            if (!ValidateObjectModelStateForTests(entity)) {
                throw new ArgumentException("Verifique se Todos os campos foram preenchidos corretamente!");
            }
            Abrigo abrigo = GetById(id);
            _mapper.Map(entity, abrigo);
            _context.SaveChanges();
            return true;
        }

        private bool ValidateObjectModelStateForTests(AbrigoDto entity) {
            if (string.IsNullOrEmpty(entity.Logradouro) || entity.Numero == null || string.IsNullOrEmpty(entity.Estado)) {
                return false;
            }
            return true;
        }
    }
}
