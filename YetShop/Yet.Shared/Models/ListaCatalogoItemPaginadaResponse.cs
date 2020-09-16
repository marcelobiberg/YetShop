using System;
using System.Collections.Generic;

namespace Yet.Shared.Models
{
    public class ListaCatalogoItemPaginadaResponse
    {
        public IReadOnlyList<CatalogoItem> CatalogoItens { get; set; } = new List<CatalogoItem>();
        public Int16 ContadorDePagina { get; set; } = 0;
    }
}
