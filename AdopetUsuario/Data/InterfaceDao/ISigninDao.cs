using AdopetUsuario.Data.Dtos;

namespace Adopet.Usuario.Data.InterfaceDao {
    public interface ISigninDao {
        Task Cadastrar(CreateUsuarioDto dto, string role);
    }
}
