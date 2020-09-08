using System;
using System.Collections.Generic;
using Yet.API.TratamentoBase;

namespace Yet.API.CatalogoItemEndpoints
{
    public class ListaPaginadaCatalogoItemResponse : BaseResponse
    {
        #region Ctor
        public ListaPaginadaCatalogoItemResponse(Guid correlacaoId) : base(correlacaoId) { }
        public ListaPaginadaCatalogoItemResponse() { }
        #endregion

        #region Campos
        public List<CatalogoItemDto> CatalogoItens { get; set; } = new List<CatalogoItemDto>();
        public int PageCount { get; set; }
        #endregion
    }
}
