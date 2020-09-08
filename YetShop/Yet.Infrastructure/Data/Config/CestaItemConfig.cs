using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Yet.Core.Entidades.CestaAgregar;

namespace Yet.Infrastructure.Data.Config
{
    public class CestaItemConfig : IEntityTypeConfiguration<CestaItem>
    {
        public void Configure(EntityTypeBuilder<CestaItem> builder)
        {
            builder.ToTable("CestaItens");
            builder.Property(bi => bi.PrecoUnit)
                .IsRequired(true)
                .HasColumnType("decimal(18,2)");
        }
    }
}
