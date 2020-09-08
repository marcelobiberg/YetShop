using System;
using System.Collections.Generic;
using Yet.API.TratamentoBase;

namespace Yet.API.CatalogoMarcaEndpoints
{
    public class ListaCatalogoMarcasResponse : BaseResponse
    {
        #region Ctor
        public ListaCatalogoMarcasResponse(Guid correlacaoId) : base(correlacaoId) { }
        public ListaCatalogoMarcasResponse() { }
        public List<CatalogoMarcaDto> CatalogoMarcas { get; set; } = new List<CatalogoMarcaDto>();
        #endregion
    }
}
