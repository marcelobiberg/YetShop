using System;
using Yet.API.TratamentoBase;

namespace Yet.API.CatalogoItemEndpoints
{
    public class ObterPorIdCatalogoItemResponse : BaseResponse
    {
        #region Ctor
        public ObterPorIdCatalogoItemResponse(Guid correlacaoId) : base(correlacaoId) { }
        public ObterPorIdCatalogoItemResponse() { }
        #endregion

        #region Campos
        public CatalogoItemDto CatalogoItem { get; set; }
        #endregion
    }
}
