using Adopet___Alura_Challenge_6.Models;
using Microsoft.EntityFrameworkCore;

namespace Adopet___Alura_Challenge_6.Data.Ef_Core {
    public class AppDbContext : DbContext{

        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt) {
        }

        public DbSet<Tutor> Tutores { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Abrigo> Abrigos { get; set; }
        public DbSet<Adocao> Adocoes { get; set; }
    }
}
