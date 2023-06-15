using AdopetUsuario.Data.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Adopet.Usuario.Services {
    public interface IAdminUserService {
        Task Cadastra(CreateUsuarioDto dto, string role);
        Task<ObjectResult> Login(LoginUsuarioDto dto);
    }
}