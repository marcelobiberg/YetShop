using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Yet.Web.Dto.Catalogo;
using Yet.Web.ViewModels.Paginacao;

namespace Yet.Web.ViewModels.Catalogo
{
    public class CatalogoViewModel
    {
        public List<CatalogoItemDto> Itens { get; set; }
        public IEnumerable<SelectListItem> Marcas { get; set; }
        public IEnumerable<SelectListItem> Tipos { get; set; }
        public uint? MarcaFiltroSelecionado { get; set; }
        public uint? TipoFiltroSelecionado { get; set; }
        public PaginacaoInfoViewModel PaginaInfo { get; set; }
    }
}
