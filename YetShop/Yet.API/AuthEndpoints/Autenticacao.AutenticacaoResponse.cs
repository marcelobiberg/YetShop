using System;
using Yet.API.TratamentoBase;


namespace Yet.API.AuthEndpoints
{
    public class AutenticacaoResponse : BaseResponse
    {
        #region Campos
        public string Email { get; set; } = string.Empty;
        public string AutenticacaoToken { get; set; } = string.Empty;
        public bool IsLockedOut { get; set; } = false;
        public bool IsNotAllowed { get; set; } = false;
        public bool Result { get; set; } = false;
        public bool IsAdmin { get; set; } = false;
        #endregion

        #region Ctor
        public AutenticacaoResponse() { }
        public AutenticacaoResponse(Guid correlacaoId) : base(correlacaoId) { }
        #endregion
    }
}
