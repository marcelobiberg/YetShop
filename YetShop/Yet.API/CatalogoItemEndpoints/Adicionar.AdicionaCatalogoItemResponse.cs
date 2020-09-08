using System;
using Yet.API.TratamentoBase;

namespace Yet.API.CatalogoItemEndpoints
{
    public class AdicionaCatalogoItemResponse : BaseResponse
    {
        #region Ctor
        public AdicionaCatalogoItemResponse(Guid correlacaoId) : base(correlacaoId) { }
        public AdicionaCatalogoItemResponse() { }
        #endregion

        #region Campos
        public CatalogoItemDto CatalogoItem { get; set; }
        #endregion
    }
}
