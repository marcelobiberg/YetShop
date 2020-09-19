using Refit;
using System.Threading.Tasks;
using Yet.Web.Areas.Site.Models.Catalogo;
using Yet.Web.Interfaces;

namespace Yet.Web.Servicos
{
    public class CatalogoServico : ICatalogoServico
    {
        public async Task<ListaCatalogoItemPaginadaResponse> ListaPaginada(ListaCatalogoItemPaginadaRequest request)
        {
            var catalogoItensClient = RestService
                .For<ICatalogoServico>("https://localhost:44307/");

            var listaPaginada = await catalogoItensClient.ListaPaginada(new ListaCatalogoItemPaginadaRequest
            {
                IndicePagina = request.IndicePagina,
                TamanhoPagina = request.TamanhoPagina,
                CatalogoMarcaId = request.CatalogoMarcaId,
                CatalogoTipoId = request.CatalogoTipoId

            });

            return listaPaginada;
        }

        public async Task<ObterCatalogoItemPorIdResponse> ObterCatalogoItemPorId(int catalogoItemId)
        {
            var catalogoItemClient = RestService
                .For<ICatalogoServico>("https://localhost:44307/");

            var catalogoItem = await catalogoItemClient.ObterCatalogoItemPorId(catalogoItemId);

            return catalogoItem;
        }
    }
}
