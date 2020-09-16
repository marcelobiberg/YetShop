using Refit;
using System.Threading.Tasks;
using Yet.Web.Interfaces;
using Yet.Web.Models;

namespace Yet.Web.Servicos
{
    public class CatalogoServico : ICatalogoServico
    {
        public async Task<ListaCatalogoItemPaginadaResponse> ListaPaginada(ListaCatalogoItemPaginadaRequest model)
        {
            var catalogoItensClient = RestService
                .For<ICatalogoServico>("https://localhost:44307/");

            var listaPaginada = await catalogoItensClient.ListaPaginada(new ListaCatalogoItemPaginadaRequest
            {
                IndicePagina = model.IndicePagina,
                TamanhoPagina = model.TamanhoPagina,
                CatalogoMarcaId = model.CatalogoMarcaId,
                CatalogoTipoId = model.CatalogoTipoId

            });

            return listaPaginada;
        }
    }
}
