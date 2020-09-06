using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Yet.Core.Entidades.CatalogoAgregar;

namespace Microsoft.eShopWeb.Infrastructure.Data.Config
{
    public class CatalogoItemConfig : IEntityTypeConfiguration<CatalogoItem>
    {
        public void Configure(EntityTypeBuilder<CatalogoItem> builder)
        {
            builder.ToTable("Catalogo");

            builder.Property(ci => ci.Id)
                .UseHiLo("catalog_hilo")
                .IsRequired();

            builder.Property(ci => ci.Nome)
                .IsRequired(true)
                .HasMaxLength(50);

            builder.Property(ci => ci.Preco)
                .IsRequired(true)
                .HasColumnType("decimal(18,2)");
                
            builder.Property(ci => ci.ImagemUri)
                .IsRequired(false);

            builder.HasOne(ci => ci.CatalogoMarca)
                .WithMany()
                .HasForeignKey(ci => ci.CatalogoMarcaId);

            builder.HasOne(ci => ci.CatalogoTipo)
                .WithMany()
                .HasForeignKey(ci => ci.CatalogoTipoId);
        }
    }
}
