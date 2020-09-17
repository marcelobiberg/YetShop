using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Yet.Web.Dto.Catalogo;

namespace Yet.Web.Areas.Site.Models.Catalogo
{
    public class ListaCatalogoItemPaginadaResponse
    {
        public List<CatalogoItemDto> CatalogoItens { get; set; }
        public IEnumerable<CatalogoTipoDto> CatalogoTipos { get; set; }
        public IEnumerable<CatalogoMarcaDto> CatalogoMarcas { get; set; }
        public byte ContadorPagina { get; set; } = 0;
    }
}
