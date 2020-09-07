using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Yet.Core.Entidades.PedidoAgregar;
using Yet.Core.Interfaces;

namespace Yet.Infrastructure.Data
{
    public class PedidoRepo : EfRepo<Pedido>, IPedidoRepo
    {
        public PedidoRepo(CatalogoContext dbContext) : base(dbContext) { }

        public Task<Pedido> ObterPedidoPorIdAsync(int id)
        {
            return _dbContext.Pedidos
                .Include(o => o.PedidoItems)
                .Include($"{nameof(Pedido.PedidoItems)}.{nameof(PedidoItem.ItemPedido)}")
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
