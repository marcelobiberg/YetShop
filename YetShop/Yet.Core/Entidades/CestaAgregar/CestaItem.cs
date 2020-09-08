using Ardalis.GuardClauses;

namespace Yet.Core.Entidades.CestaAgregar
{
    public class CestaItem : EntidadeBase
    {
        #region Campos
        public decimal PrecoUnit { get; private set; }
        public int Quantidade { get; private set; }
        public int CatalogoItemId { get; private set; }
        public int CestaId { get; private set; }
        #endregion

        #region Ctor
        public CestaItem() { }

        public CestaItem(int catalogoItemId, int quantidade, decimal precoUnit)
        {
            CatalogoItemId = catalogoItemId;
            PrecoUnit = precoUnit;
            SetQuantidade(quantidade);
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Soma "quantidade" ao carrinho de compras ( Cesta )
        /// </summary>
        /// <param name="qtd">Quantidades a ser adicionada</param>
        public void AddQuantidade(int qtd)
        {
            Guard.Against.OutOfRange(qtd, nameof(qtd), 0, int.MaxValue);
            Quantidade += qtd;
        }

        /// <summary>
        /// Setta "quantidade" ao carrinho de compras ( Cesta )
        /// </summary>
        /// <param name="qtd">Quantidades a ser declarada na propriedade Quantidade</param>
        public void SetQuantidade(int qtd)
        {
            Guard.Against.OutOfRange(qtd, nameof(qtd), 0, int.MaxValue);
            Quantidade = qtd;
        }
        #endregion
    }
}
