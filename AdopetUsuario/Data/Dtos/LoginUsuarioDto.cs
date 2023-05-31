using System.ComponentModel.DataAnnotations;

namespace AdopetUsuario.Data.Dtos {
    public class LoginUsuarioDto {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
