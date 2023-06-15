using Adopet.Usuario.Data.InterfaceDao;
using Adopet.Usuario.Services.Handler;
using AdopetUsuario.Data.Dtos;
using AdopetUsuario.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Adopet.Usuario.Data.EfCore {
    public class LoginDaoComEfCore : ILoginDao {
        private SignInManager<User> _signInManager;
        private TokenService _tokenService;

        public LoginDaoComEfCore(SignInManager<User> signInManager, TokenService tokenService) {
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task<ObjectResult> Login(LoginUsuarioDto dto) {
            var resultado = await _signInManager.PasswordSignInAsync(dto.Username, dto.Password, false, false);

            if (!resultado.Succeeded) {
                return new ObjectResult("Login ou Senha Incorretos") { StatusCode = 403};
            }

            var usuario = _signInManager.UserManager.Users.FirstOrDefault(user => user.NormalizedUserName == dto.Username.ToUpper());

            var token = _tokenService.GenerateToken(usuario, _signInManager.UserManager.GetRolesAsync(usuario).Result.FirstOrDefault());

            return new ObjectResult(token) { StatusCode = 200};
        }
    }
}