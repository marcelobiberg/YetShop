using System.Threading.Tasks;
using Yet.Core.Entidades.PedidoAgregar;

namespace Yet.Core.Interfaces
{
    /// <summary>
    /// Tasks reponsáveis por manipular os serviços do pedido
    /// </summary>
    public interface IPedidoServico
    {
        Task CriarPedidoAsync(int cestaId, Endereco enderecoEntrega);
    }
}
