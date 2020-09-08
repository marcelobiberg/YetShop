using System;

namespace Yet.API.TratamentoBase
{
    /// <summary>
    /// Classe base usada na API
    /// </summary>
    public abstract class BaseMessage
    {
        /// <summary>
        /// Identificador unico ( Id da sessão ) usado pelo logging 
        /// </summary>
        protected Guid _correlacaoId = Guid.NewGuid();
        public Guid CorrelacaoId() => _correlacaoId;
    }
}
