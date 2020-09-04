using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;

namespace Yet.Core.Entidades.PedidoAgregar
{
    public class Pedido : EntidadeBase
    {
        #region Campos
        public string CompradorId { get; private set; }
        public DateTimeOffset CreatedOn { get; private set; } = DateTimeOffset.Now;
        public Endereco EnderecoEntrega { get; private set; }
        private readonly List<PedidoItem> _pedidoItens = new List<PedidoItem>();

        // Using List<>.AsReadOnly() 
        // This will create a read only wrapper around the private list so is protected against "external updates".
        // It's much cheaper than .ToList() because it will not have to copy all items in a new collection. (Just one heap alloc for the wrapper instance)
        //https://msdn.microsoft.com/en-us/library/e78dcd75(v=vs.110).aspx 
        public IReadOnlyCollection<PedidoItem> PedidoItems => _pedidoItens.AsReadOnly();
        #endregion

        #region Ctor
        private Pedido() { }

        public Pedido(string compradorId, Endereco enderecoEntrega, List<PedidoItem> itens)
        {
            Guard.Against.NullOrEmpty(compradorId, nameof(compradorId));
            Guard.Against.Null(enderecoEntrega, nameof(enderecoEntrega));
            Guard.Against.Null(itens, nameof(itens));

            CompradorId = compradorId;
            EnderecoEntrega = enderecoEntrega;
            _pedidoItens = itens;
        }
        #endregion

        #region Métodos
        public decimal Total()
        {
            var total = 0m;
            foreach (var item in _pedidoItens)
            {
                total += item.PrecoUnit * item.Unidades;
            }
            return total;
        }
        #endregion
    }
}
