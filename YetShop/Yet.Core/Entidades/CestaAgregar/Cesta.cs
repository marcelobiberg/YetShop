using System.Collections.Generic;
using System.Linq;

namespace Yet.Core.Entidades.CestaAgregar
{
    public class Cesta : EntidadeBase
    {
        #region Campos
        public string CompradorId { get; private set; }
        private readonly List<CestaItem> _items = new List<CestaItem>();
        public IReadOnlyCollection<CestaItem> Items => _items.AsReadOnly();
        #endregion

        #region Ctor
        public Cesta(string compradorId)
        {
            CompradorId = compradorId;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Adiciona item ao carrinho de compras ( Cesta )
        /// </summary>
        /// <param name="catalogoItemId">ID do item no catálogo</param>
        /// <param name="precoUnit">Valor da unidade</param>
        /// <param name="qtd">Quantidades de itens no cesto</param>
        public void AdicionarItem(int catalogoItemId, decimal precoUnit, int qtd = 1)
        {
            if (!Items.Any(i => i.CatalogoItemId == catalogoItemId))
            {
                _items.Add(new CestaItem(catalogoItemId, qtd, precoUnit));
                return;
            }
            var duplicado = Items.FirstOrDefault(i => i.CatalogoItemId == catalogoItemId);
            duplicado.AddQuantidade(qtd);
        }

        /// <summary>
        /// Remove itens vazios do carrinho de compras ( Cesta )
        /// </summary>
        public void RemoveItensVazios()
        {
            _items.RemoveAll(i => i.Quantidade == 0);
        }
        #endregion
    }
}
