using System;

namespace Yet.Core.Excecoes
{
    public class CestaVaziaAoFinalizarException : Exception
    {
        public CestaVaziaAoFinalizarException()
            : base($"Cesta não pode ter 0 items ao finalizar pedido") { }

        protected CestaVaziaAoFinalizarException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

        public CestaVaziaAoFinalizarException(string message) : base(message) { }

        public CestaVaziaAoFinalizarException(string message, Exception innerException) : base(message, innerException) { }
    }
}
