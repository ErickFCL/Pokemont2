using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancistoCloneWeb.Models.Maps
{
    public class UsuarioPokemonGoMap : IEntityTypeConfiguration<UsuarioPokemonGo>
    {
        public void Configure(EntityTypeBuilder<UsuarioPokemonGo> builder)
        {
            builder.ToTable("UsuarioPokemonGo");
            builder.HasKey(o => o.Id);

            

            //Pokemones
            builder.HasOne(o => o.PokemonGos).
                WithMany(o => o.UsuarioPokemonGos).
                HasForeignKey(o => o.IdPokemonGo);

            //usuarios

            builder.HasOne(o => o.Users).
                WithMany(o => o.UsuarioPokemonGos).
                HasForeignKey(o => o.IdUser);

        }
    }
}
