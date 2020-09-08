using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Yet.Core.Entidades.PedidoAgregar;

namespace Yet.Infrastructure.Data.Config
{
    public class PedidoConfig : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            var navigation = builder.Metadata.FindNavigation(nameof(Pedido.PedidoItens));

            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.ToTable("Pedidos");
            builder.OwnsOne(o => o.EnderecoEntrega, a =>
            {
                a.WithOwner();

                a.Property(a => a.Cep)
                    .HasMaxLength(18)
                    .IsRequired();

                a.Property(a => a.Rua)
                    .HasMaxLength(180)
                    .IsRequired();

                a.Property(a => a.Estado)
                    .HasMaxLength(60);

                a.Property(a => a.Pais)
                    .HasMaxLength(90)
                    .IsRequired();

                a.Property(a => a.Cidade)
                    .HasMaxLength(100)
                    .IsRequired();
            });
        }
    }
}
