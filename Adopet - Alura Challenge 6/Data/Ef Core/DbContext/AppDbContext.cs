using Adopet___Alura_Challenge_6.Models;
using Microsoft.EntityFrameworkCore;

namespace Adopet___Alura_Challenge_6.Data.Ef_Core {
    public class AppDbContext : DbContext{

        public AppDbContext() {
        }

        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt) {
        }

        public virtual DbSet<Tutor> Tutores { get; set; }
        public virtual DbSet<Pet> Pets { get; set; }
        public virtual DbSet<Abrigo> Abrigos { get; set; }
        public virtual DbSet<Adocao> Adocoes { get; set; }
    }
}
