using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yet.Web.Areas.Site.Models.Catalogo;
using Yet.Web.Constantes;
using Yet.Web.Dto.Catalogo;
using Yet.Web.Interfaces;
using Yet.Web.ViewModels.Catalogo;
using Yet.Web.ViewModels.Paginacao;

namespace Yet.Web.Areas.Site.Controllers
{
    [Area("Site")]
    public class CatalogoController : Controller
    {
        #region Campos
        private readonly ICatalogoServico _CatalogoServico;
        private ILogger<ICatalogoServico> _logger;
        #endregion

        #region Ctor
        public CatalogoController(ICatalogoServico catalogoItemServico,
            ILogger<ICatalogoServico> logger)
        {
            _CatalogoServico = catalogoItemServico;
            _logger = logger;
        }
        #endregion

        [HttpGet]
        public async Task<ActionResult<CatalogoViewModel>> Index(byte indicePagina,
            uint? marcaFiltroSelecionado,
            uint? tipoFiltroSelecionado,
            byte ItensPagina = Paginacao.ITENS_POR_PAGINA)
        {
            _logger.LogInformation("Buscando o catálogo de itens na API");
            var response = await _CatalogoServico.ListaPaginada(new ListaCatalogoItemPaginadaRequest
            {
                IndicePagina = indicePagina,
                TamanhoPagina = ItensPagina,
                CatalogoMarcaId = marcaFiltroSelecionado,
                CatalogoTipoId = tipoFiltroSelecionado
            });

            var totalItens = response.ContadorPagina;

            var vm = new CatalogoViewModel
            {
                Itens = response.CatalogoItens.ToList(),

                // Combo para catálogo marcas 
                Marcas = ComboCatalogoMarcas(response.CatalogoMarcas),
                // Combo para catálogo tipos 
                Tipos = ComboCatalogoTipos(response.CatalogoTipos),

                MarcaFiltroSelecionado = marcaFiltroSelecionado ?? 0,
                TipoFiltroSelecionado = tipoFiltroSelecionado ?? 0,

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

        #region Combo Helpers
        public static IEnumerable<SelectListItem> ComboCatalogoMarcas(IEnumerable<CatalogoMarcaDto> marcas)
        {
            var itens = marcas
               .Select(type => new SelectListItem() { Value = type.Id.ToString(), Text = type.Nome })
               .OrderBy(t => t.Text)
               .ToList();

            var todos = new SelectListItem() { Value = null, Text = "Todos", Selected = true };
            itens.Insert(0, todos);

            return itens;
        }

        public static IEnumerable<SelectListItem> ComboCatalogoTipos(IEnumerable<CatalogoTipoDto> tipos)
        {
            var itens = tipos
               .Select(type => new SelectListItem() { Value = type.Id.ToString(), Text = type.Nome })
               .OrderBy(t => t.Text)
               .ToList();

            var todos = new SelectListItem() { Value = null, Text = "Todos", Selected = true };
            itens.Insert(0, todos);

            return itens;
        }
        #endregion
    }
}
