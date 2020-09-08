using Ardalis.Specification;
using Yet.Core.Entidades.PedidoAgregar;

namespace Yet.Core.Especificacoes
{
    public class ClientePedidosComItensQuery : Specification<Pedido>
    {
        public ClientePedidosComItensQuery(string compradorId)
        {
            Query.Where(o => o.CompradorId == compradorId)
                .Include(o => o.PedidoItens)
                    .ThenInclude(i => i.ItemPedido);
        }
    }
}
