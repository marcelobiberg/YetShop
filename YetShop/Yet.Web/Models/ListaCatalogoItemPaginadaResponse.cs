using System.Collections.Generic;

namespace Yet.Web.Models
{
    public class ListaCatalogoItemPaginadaResponse
    {
        public List<CatalogoItemDto> CatalogoItens { get; set; }
        public byte ContadorPagina { get; set; } = 0;
    }
}
