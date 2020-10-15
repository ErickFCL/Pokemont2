using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancistoCloneWeb.Models.Maps
{
    public class PokemonGoMap : IEntityTypeConfiguration<PokemonGo>
    {
        public void Configure(EntityTypeBuilder<PokemonGo> builder)
        {
            builder.ToTable("PokemonGo");
            builder.HasKey(o => o.Id);

            //builder.HasOne(o => o.Type)
            //    .WithMany(o => o.Accounts)
            //    .HasForeignKey(o => o.TypeId);

            builder.HasOne(o => o.Tipo)
                .WithMany()
                .HasForeignKey(o => o.TipoId);

            builder.HasMany(o => o.UsuarioPokemonGos).
                WithOne(o => o.PokemonGos).
                HasForeignKey(o => o.IdPokemonGo);
        }
    }
}
