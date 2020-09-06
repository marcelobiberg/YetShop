using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Yet.Core.Entidades.CatalogoAgregar;

namespace Microsoft.eShopWeb.Infrastructure.Data.Config
{
    public class CatalogoTipoConfig : IEntityTypeConfiguration<CatalogoTipo>
    {
        public void Configure(EntityTypeBuilder<CatalogoTipo> builder)
        {
            builder.HasKey(ci => ci.Id);

            builder.Property(ci => ci.Id)
               .UseHiLo("catalog_type_hilo")
               .IsRequired();

            builder.Property(cb => cb.Tipo)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
