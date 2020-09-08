using System;

namespace Yet.API.TratamentoBase
{
    /// <summary>
    /// Classe base usada no Response da API
    /// </summary>
    public abstract class BaseResponse : BaseMessage
    {
        public BaseResponse(Guid correlationId) : base()
        {
            base._correlacaoId = correlationId;
        }

        public BaseResponse() { }
    }
}
