using Microsoft.Extensions.Configuration;
using Refit;
using System.Threading.Tasks;
using Yet.Web.Interfaces;
using Yet.Web.Models.Catalogo;

namespace Yet.Web.Servicos
{
    public class CatalogoServico : ICatalogoServico
    {
        #region Campos
        private readonly IConfiguration _configuration;
        private readonly string _baseUrlApi;
        #endregion

        #region Ctor
        public CatalogoServico(IConfiguration configuration)
        {
            _configuration = configuration;
            _baseUrlApi = _configuration["BaseUrls:apiBase"];
        }
        #endregion

        #region Métodos
        public async Task<ListaCatalogoItemPaginadaResponse> ListaPaginada(ListaCatalogoItemPaginadaRequest request)
        {
            var catalogoItensClient = RestService
                .For<ICatalogoServico>(_baseUrlApi);

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
                .For<ICatalogoServico>(_baseUrlApi);

            var catalogoItem = await catalogoItemClient.ObterCatalogoItemPorId(catalogoItemId);

            return catalogoItem;
        }
        #endregion
    }
}
