using AdopetUsuario.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AdopetUsuario.Data {
    public class UsuarioDbContext : IdentityDbContext<Usuario>{

        public UsuarioDbContext(DbContextOptions<UsuarioDbContext> opt) : base(opt){

        }
    }
}
