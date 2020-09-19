using Refit;
using System.Threading.Tasks;
using Yet.Web.Areas.Site.Models.Catalogo;

namespace Yet.Web.Interfaces
{
    public interface ICatalogoServico
    {
        [Get("/api/catalogo-itens-paginado")]
        Task<ListaCatalogoItemPaginadaResponse> ListaPaginada(ListaCatalogoItemPaginadaRequest request);

        [Get("/api/catalogo-item/{CatalogoItemId}")]
        Task<ObterCatalogoItemPorIdResponse> ObterCatalogoItemPorId(int CatalogoItemId);
    }
}