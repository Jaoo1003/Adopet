using AdopetUsuario.Data.Dtos;
using AdopetUsuario.Models;
using Microsoft.AspNetCore.Identity;

namespace AdopetUsuario.Services {
    public class LoginService {
        private SignInManager<Usuario> _signInManager;
        private TokenService _tokenService;

        public LoginService(SignInManager<Usuario> signInManager, TokenService tokenService) {
            _signInManager = signInManager;
            _tokenService = tokenService;
        }
        public async Task<string> Login(LoginUsuarioDto dto) {
            var resultado = await _signInManager.PasswordSignInAsync(dto.Username, dto.Password, false, false);

            if (!resultado.Succeeded) {
                return null;
            }

            var usuario = _signInManager.UserManager.Users.FirstOrDefault(user => user.NormalizedUserName == dto.Username.ToUpper());

            var token = _tokenService.GenerateToken(usuario, _signInManager.UserManager.GetRolesAsync(usuario).Result.FirstOrDefault());

            return token;
        }
    }
}