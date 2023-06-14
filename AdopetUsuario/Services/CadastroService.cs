using AdopetUsuario.Data.Dtos;
using AdopetUsuario.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace AdopetUsuario.Services {
    public class UsuarioService {
        private IMapper _mapper;
        private UserManager<Usuario> _userManager;

        public UsuarioService(IMapper mapper, UserManager<Usuario> userManager) {
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task Cadastra(CreateUsuarioDto dto, string role) {
            Usuario usuario = _mapper.Map<Usuario>(dto);

            IdentityResult resultado = await _userManager.CreateAsync(usuario, dto.Password);            

            if (!resultado.Succeeded) {
                throw new ApplicationException("Falha ao cadastrar usuário");
            }

            await _userManager.AddToRoleAsync(usuario, role);
            await _userManager.AddToRoleAsync(usuario, "Cadastrado");
        }
    }
}