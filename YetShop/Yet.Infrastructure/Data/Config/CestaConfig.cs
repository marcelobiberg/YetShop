using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Yet.Core.Entidades.CestaAgregar;

namespace Yet.Infrastructure.Data.Config
{
    public class CestaConfig : IEntityTypeConfiguration<Cesta>
    {
        public void Configure(EntityTypeBuilder<Cesta> builder)
        {
            var navigation = builder.Metadata.FindNavigation(nameof(Cesta.Items));
            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.Property(b => b.CompradorId)
                .IsRequired()
                .HasMaxLength(40);
        }
    }
}
