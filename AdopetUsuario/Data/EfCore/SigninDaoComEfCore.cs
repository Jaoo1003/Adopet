using Adopet.Usuario.Data.InterfaceDao;
using AdopetUsuario.Data.Dtos;
using AdopetUsuario.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace Adopet.Usuario.Data.EfCore {
    public class SigninDaoComEfCore : ISigninDao {
        private IMapper _mapper;
        private UserManager<User> _userManager;

        public SigninDaoComEfCore(IMapper mapper, UserManager<User> userManager) {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task Cadastrar(CreateUsuarioDto dto, string role) {
            User usuario = _mapper.Map<User>(dto);            

            IdentityResult resultado = await _userManager.CreateAsync(usuario, dto.Password);

            if (!resultado.Succeeded) {
                throw new ApplicationException("Falha ao cadastrar usuário " + resultado);
            }

            await _userManager.AddToRoleAsync(usuario, role);
        }
    }
}