using AdopetUsuario.Data.Dtos;
using AdopetUsuario.Models;
using Microsoft.AspNetCore.Identity;

namespace AdopetUsuario.Services {
    public class LoginService {
        private SignInManager<Usuario> _signInManager;

        public LoginService(SignInManager<Usuario> signInManager) {
            _signInManager = signInManager;
        }
        public async Task Login(LoginUsuarioDto dto) {
            var resultado = await _signInManager.PasswordSignInAsync(dto.Username, dto.Password, false, false);

            if (!resultado.Succeeded) {
                throw new ApplicationException("Usuário não autenticado!");
            }
        }
    }
}