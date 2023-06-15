using Adopet.Usuario.Data.InterfaceDao;
using AdopetUsuario.Data.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Adopet.Usuario.Services.Handler {
    public class DefaultAdminUserService : IAdminUserService {
        private readonly ILoginDao _loginDao;
        private readonly ISigninDao _SigninDao;

        public DefaultAdminUserService(ILoginDao loginDao, ISigninDao signinDao) {
            _loginDao = loginDao;
            this._SigninDao = signinDao;
        }

        public async Task Cadastra(CreateUsuarioDto dto, string role) {
            await _SigninDao.Cadastrar(dto, role);
        }

        public async Task<ObjectResult> Login(LoginUsuarioDto dto) {
            var token = await _loginDao.Login(dto);
            return token;
        }
    }
}