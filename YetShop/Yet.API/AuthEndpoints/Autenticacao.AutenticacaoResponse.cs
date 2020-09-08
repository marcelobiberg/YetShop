using System;
using Yet.API.TratamentoBase;


namespace Yet.API.AuthEndpoints
{
    public class AutenticacaoResponse : BaseResponse
    {
        #region Ctor
        public AutenticacaoResponse() { }
        public AutenticacaoResponse(Guid correlacaoId) : base(correlacaoId) { }
        #endregion

        #region Propriedades
        public string Usuario { get; set; } = string.Empty;
        public string AutenticacaoToken { get; set; } = string.Empty;
        public bool IsLockedOut { get; set; } = false;
        public bool IsNotAllowed { get; set; } = false;
        public bool Result { get; set; } = false;
        #endregion
    }
}
