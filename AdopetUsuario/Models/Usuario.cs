using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AdopetUsuario.Models {
    public class Usuario : IdentityUser<int>{

        public Usuario() : base() { }
    }
}
