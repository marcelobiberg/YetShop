using System.Collections.Generic;
using System.Threading.Tasks;

namespace Yet.Core.Interfaces
{
    /// <summary>
    /// Tasks reponsáveis por manipular os serviços do carrinho de compras ( Cesta )
    /// </summary>
    public interface ICestaServico
    {
        Task TransferirCestaAsync(string anonymousId, string userName);
        Task AdicionarItemParaCestaAsync(int cestaId, int catalogoItemId, decimal preco, int quantidade = 1);
        Task SetQuantidadesAsync(int cestaId, Dictionary<string, int> quantidades);
        Task RemoveCestaAsync(int cestaId);
    }
}
