using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Yet.Core.Entidades.PedidoAgregar;

namespace Yet.Infrastructure.Data.Config
{
    public class PedidoItemConfig : IEntityTypeConfiguration<PedidoItem>
    {
        public void Configure(EntityTypeBuilder<PedidoItem> builder)
        {
            builder.ToTable("PedidoItens");
            builder.OwnsOne(i => i.ItemPedido, io =>
            {
                io.WithOwner();

                io.Property(cio => cio.ProdutoNome)
                    .HasMaxLength(50)
                    .IsRequired();
            });

            builder.Property(oi => oi.PrecoUnit)
                .IsRequired(true)
                .HasColumnType("decimal(18,2)");
        }
    }
}
