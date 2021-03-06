﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinancistoCloneWeb.Models.Maps
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(o => o.Id);

            builder.HasMany(o => o.UsuarioPokemonGos).
                WithOne(o => o.Users).
                HasForeignKey(o => o.IdUser);
        }
    }
}
