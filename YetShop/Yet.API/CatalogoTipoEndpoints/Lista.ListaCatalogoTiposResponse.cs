using System;
using System.Collections.Generic;
using Yet.API.TratamentoBase;

namespace Yet.API.CatalogoTipoEndpoints
{
    public class ListaCatalogoTiposResponse : BaseResponse
    {
        public ListaCatalogoTiposResponse(Guid correlacaoId) : base(correlacaoId) { }

        public ListaCatalogoTiposResponse() { }

        public List<CatalogoTipoDto> CatalogoTipos { get; set; } = new List<CatalogoTipoDto>();
    }
}
