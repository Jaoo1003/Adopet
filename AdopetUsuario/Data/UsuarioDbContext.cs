using AdopetUsuario.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AdopetUsuario.Data {
    public class UsuarioDbContext : IdentityDbContext<Usuario, IdentityRole<int>, int>{

        public UsuarioDbContext(DbContextOptions<UsuarioDbContext> opt) : base(opt){
        }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole<int>>().HasData(
                new IdentityRole<int> { Id = 1, Name = "Tutor", NormalizedName = "TUTOR"},
                new IdentityRole<int> { Id = 2, Name = "Abrigo", NormalizedName = "ABRIGO"}
                );
        }
    }
}