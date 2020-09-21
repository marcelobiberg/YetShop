using System.Threading.Tasks;
using Yet.Core.Entidades.CatalogoAgregar;

namespace Yet.Core.Interfaces
{
    public interface ICatalogoRepo : IRepoAsync<CatalogoItem>
    {
        Task<CatalogoItem> ObterCatalogoItemPorIdAsync(int id);
    }
}
