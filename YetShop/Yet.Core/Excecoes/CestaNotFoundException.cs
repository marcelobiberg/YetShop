using System;

namespace Yet.Core.Excecoes
{
    public class CestaNotFoundException : Exception
    {
        public CestaNotFoundException(int basketId) : base($"Carrinho de compra com o ID ( {basketId} )") { }

        protected CestaNotFoundException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

        public CestaNotFoundException(string message) : base(message) { }

        public CestaNotFoundException(string message, Exception innerException) : base(message, innerException) { }
    }
}
