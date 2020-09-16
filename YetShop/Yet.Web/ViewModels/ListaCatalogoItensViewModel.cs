using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Yet.Web.ViewModels
{
    public class ListaCatalogoItensViewModel
    {
        public List<CatalogoItemViewModel> CatalogoItens { get; set; }
        public List<SelectListItem> Marcas { get; set; }
        public List<SelectListItem> Tipos { get; set; }
        public int? MarcaFiltroSelecionado { get; set; }
        public int? TipoFiltroSelecionado { get; set; }
        public PaginacaoInfoViewModel PaginaInfo { get; set; }
    }
}
