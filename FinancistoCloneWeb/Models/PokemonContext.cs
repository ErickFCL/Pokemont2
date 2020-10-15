using FinancistoCloneWeb.Models.Maps;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancistoCloneWeb.Models
{
    public class PokemonContext : DbContext
    {
        //Esto se hace por cada tabla de base de datos
        public DbSet<PokemonGo> PokemonGos { get; set; }
        public DbSet<Tipo> TiposL { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UsuarioPokemonGo> UsuarioPokemonGos { get; set; }

        public PokemonContext(DbContextOptions<PokemonContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Esto se hace por cada tabla de base de datos
            modelBuilder.ApplyConfiguration(new PokemonGoMap());
            modelBuilder.ApplyConfiguration(new TipoMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new UsuarioPokemonGoMap());
        }

    }
}
