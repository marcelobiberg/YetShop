using Ardalis.GuardClauses;

namespace Yet.Core.Entidades.PedidoAgregar
{
    public class CatalogoItemPedido
    {
        #region Campos
        public int CatalogoItemId { get; private set; }
        public string ProdutoNome { get; private set; }
        #endregion

        #region Ctor
        private CatalogoItemPedido() { }

        public CatalogoItemPedido(int catalogoItemId, string produtoNome)
        {
            Guard.Against.OutOfRange(catalogoItemId, nameof(catalogoItemId), 1, int.MaxValue);
            Guard.Against.NullOrEmpty(ProdutoNome, nameof(ProdutoNome));

            CatalogoItemId = catalogoItemId;
            ProdutoNome = ProdutoNome;
        }
        #endregion
    }
}
