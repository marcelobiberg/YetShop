using Refit;
using System.Threading.Tasks;
using Yet.Web.Models;

namespace Yet.Web.Interfaces
{
    public interface ICatalogoServico
    {
        [Get("/api/catalogo-itens-paginado")]
        Task<ListaCatalogoItemPaginadaResponse> ListaPaginada(ListaCatalogoItemPaginadaRequest request);
    }
}