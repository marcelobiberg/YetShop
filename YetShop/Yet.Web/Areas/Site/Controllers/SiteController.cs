using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using Yet.Web.Constantes;
using Yet.Web.Interfaces;
using Yet.Web.Models;
using Yet.Web.ViewModels;

namespace Yet.Web.Areas.Site.Controllers
{
    [Area("Site")]
    public class SiteController : Controller
    {
        #region Campos
        private readonly ICatalogoServico _CatalogoItemServico;
        private ILogger<ICatalogoServico> _logger;
        #endregion

        #region Ctor
        public SiteController(ICatalogoServico catalogoItemServico,
            ILogger<ICatalogoServico> logger)
        {
            _CatalogoItemServico = catalogoItemServico;
            _logger = logger;
        }
        #endregion

        [HttpGet]
        public async Task<ActionResult<CatalogoViewModel>> Catalogo(byte indicePagina, 
            uint? marcaId, 
            uint? tipoId, 
            byte ItensPagina = Paginacao.ITENS_POR_PAGINA)
        {
            _logger.LogInformation("Buscando o catálogo de itens na API");
            var catalogoItens = await _CatalogoItemServico
                .ListaPaginada(new ListaCatalogoItemPaginadaRequest
            {
                IndicePagina = indicePagina,
                TamanhoPagina = ItensPagina,
                CatalogoMarcaId = marcaId,
                CatalogoTipoId = tipoId
            });

            //TODO: ajustar para buscar na api a lista de Marcas e Tipos
            var marcaList = new[]
                {
                    new SelectListItem { Value = "2", Text = "Selecione", Selected=true },
                    new SelectListItem { Value = "1", Text = "Ativo" },
                    new SelectListItem { Value = "0", Text = "Inativo" },
                };
            var tipoList = new[]
                {
                    new SelectListItem { Value = "2", Text = "Selecione", Selected=true },
                    new SelectListItem { Value = "1", Text = "Ativo" },
                    new SelectListItem { Value = "0", Text = "Inativo" },
                };

            var totalItens = catalogoItens.ContadorPagina;

            var vm = new CatalogoViewModel
            {
                Itens = catalogoItens.CatalogoItens.ToList(),
                Marcas = new SelectList(marcaList, "Value", "Text").ToList(),
                Tipos = new SelectList(tipoList, "Value", "Text").ToList(),
                MarcaFiltroSelecionado = marcaId ?? 0,
                TipoFiltroSelecionado = tipoId ?? 0,
                PaginaInfo = new PaginacaoInfoViewModel
                {
                    PaginaAtual = indicePagina,
                    ItensPorPagina = ItensPagina,
                    TotalItens = totalItens,
                    TotalPaginas = int.Parse(Math.Ceiling(((decimal)totalItens / ItensPagina)).ToString())
                }
            };

            vm.PaginaInfo.Proximo = (vm.PaginaInfo.PaginaAtual == vm.PaginaInfo.TotalPaginas - 1) ? "is-disabled" : "";
            vm.PaginaInfo.Anterior = (vm.PaginaInfo.PaginaAtual == 0) ? "is-disabled" : "";


            return View(vm);
        }
    }
}
