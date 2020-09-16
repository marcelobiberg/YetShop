using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Yet.Web.Models;

namespace Yet.Web.ViewModels
{
    public class CatalogoViewModel
    {
        public List<CatalogoItemDto> Itens { get; set; }
        public List<SelectListItem> Marcas { get; set; }
        public List<SelectListItem> Tipos { get; set; }
        public uint? MarcaFiltroSelecionado { get; set; }
        public uint? TipoFiltroSelecionado { get; set; }
        public PaginacaoInfoViewModel PaginaInfo { get; set; }
    }
}
