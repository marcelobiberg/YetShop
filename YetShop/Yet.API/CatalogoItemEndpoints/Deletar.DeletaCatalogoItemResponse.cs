using System;
using Yet.API.TratamentoBase;

namespace Yet.API.CatalogoItemEndpoints
{
    public class DeletaCatalogoItemResponse : BaseResponse
    {
        #region Ctor
        public DeletaCatalogoItemResponse(Guid correlacaoId) : base(correlacaoId) { }
        public DeletaCatalogoItemResponse() { }
        #endregion

        #region Campos
        public string Status { get; set; } = "Deletado";
        #endregion
    }
}
