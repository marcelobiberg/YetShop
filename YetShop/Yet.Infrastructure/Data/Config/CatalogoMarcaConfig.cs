﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Yet.Core.Entidades.CatalogoAgregar;

namespace Yet.Infrastructure.Data.Config
{
    public class CatalogoMarcaConfig : IEntityTypeConfiguration<CatalogoMarca>
    {
        public void Configure(EntityTypeBuilder<CatalogoMarca> builder)
        {
            builder.ToTable("CatalogoMarcas");
            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Id)
               .UseHiLo("catalogo_marca_hilo")
               .IsRequired();

            builder.Property(cb => cb.Marca)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
