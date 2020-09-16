using System;
using System.Collections.Generic;
using Yet.API.TratamentoBase;

namespace Yet.API.CatalogoItemEndpoints
{
    public class ListaPaginadaCatalogoItemResponse : BaseResponse
    {
        #region Campos
        public List<CatalogoItemDto> CatalogoItens { get; set; } = new List<CatalogoItemDto>();
        public int ContadorPagina { get; set; }
        #endregion

        #region Ctor
        public ListaPaginadaCatalogoItemResponse() { }
        public ListaPaginadaCatalogoItemResponse(Guid correlacaoId) : base(correlacaoId) { }
        #endregion
    }
}
