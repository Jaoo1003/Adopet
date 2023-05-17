﻿using Adopet___Alura_Challenge_6.Models;
using Microsoft.EntityFrameworkCore;

namespace Adopet___Alura_Challenge_6.Data.Ef_Core {
    public class AppDbContext : DbContext{

        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt) {
        }

        public DbSet<Tutor> Tutores { get; set; }
    }
}