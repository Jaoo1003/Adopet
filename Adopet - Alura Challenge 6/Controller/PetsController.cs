using Adopet___Alura_Challenge_6.Data.Ef_Core;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Adopet___Alura_Challenge_6.Controller {
    [ApiController]
    [Route("[controller]")]
    public class PetsController : ControllerBase{
        private IMapper _mapper;
        private AppDbContext _context;
        public PetsController(IMapper mapper, AppDbContext context) {
            _mapper = mapper;
            _context = context;
        }


    }
}
