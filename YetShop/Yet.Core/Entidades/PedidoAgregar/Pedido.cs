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
        public IReadOnlyCollection<PedidoItem> PedidoItens => _pedidoItens.AsReadOnly();
        #endregion

        #region Ctor
        public Pedido() { }

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
