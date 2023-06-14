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
            Abrigo abrigo = _mapper.Map<Abrigo>(entity);
            _context.Add(abrigo);
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
    }
}
