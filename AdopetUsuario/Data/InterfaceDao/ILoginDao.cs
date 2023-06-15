using AdopetUsuario.Data.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Adopet.Usuario.Data.InterfaceDao {
    public interface ILoginDao {
        Task<ObjectResult> Login(LoginUsuarioDto dto);
    }
}
