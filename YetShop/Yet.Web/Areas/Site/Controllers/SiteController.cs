using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Yet.Shared.Interfaces;
using Yet.Web.Constantes;
using Yet.Web.ViewModels;

namespace Yet.Web.Areas.Site.Controllers
{
    [Area("Site")]
    public class SiteController : Controller
    {
        #region Campos
        private readonly ICatalogoItemServico _CatalogoItemServico;
        private ILogger<ICatalogoItemServico> _logger;
        #endregion

        #region Ctor
        public SiteController(ICatalogoItemServico catalogoItemServico,
            ILogger<ICatalogoItemServico> logger)
        {
            _CatalogoItemServico = catalogoItemServico;
            _logger = logger;

        }
        #endregion

        [HttpGet]
        public async Task<IActionResult> ListaCatalogoItens(ListaCatalogoItensViewModel model, int? paginaId)
        {
            _logger.LogInformation("Buscando o catálogo de itens na API");

            var catalogoItens = await _CatalogoItemServico.ListaPaginada(paginaId ?? 0, Paginacao.ITENS_POR_PAGINA, model.MarcaFiltroSelecionado, model.TipoFiltroSelecionado);

            return View();
        }
    }
}
