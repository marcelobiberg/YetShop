using System;

namespace Yet.Core.Excecoes
{
    public class CestaNaoEncontradaException : Exception
    {
        public CestaNaoEncontradaException(int basketId) : base($"Carrinho de compra com o ID ( {basketId} )") { }

        protected CestaNaoEncontradaException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

        public CestaNaoEncontradaException(string message) : base(message) { }

        public CestaNaoEncontradaException(string message, Exception innerException) : base(message, innerException) { }
    }
}
