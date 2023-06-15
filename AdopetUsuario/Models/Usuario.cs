using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AdopetUsuario.Models {
    public class User : IdentityUser<int>{

        public User() : base() { }
    }
}
