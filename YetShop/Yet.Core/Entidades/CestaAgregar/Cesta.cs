using System.Collections.Generic;
using System.Linq;

namespace Yet.Core.Entidades.CestaAgregar
{
    public class Cesta : EntidadeBase
    {
        #region Campos
        public string CompradorId { get; private set; }

        // Padrão DDD observações
        // Infraestrutura no Entity Framework Core da perspectiva do DDD https://docs.microsoft.com/pt-br/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/infrastructure-persistence-layer-implementation-entity-framework-core#infrastructure-in-entity-framework-core-from-a-ddd-perspective
        // ( IReadOnlyCollection<CestaItem> Items ) encapsulado e somente acessado pelo método Cesta.AdicionarItem() evitando 'updates externos'
        private readonly List<CestaItem> _items = new List<CestaItem>();

        // Using List<>.AsReadOnly() 
        // This will create a read only wrapper around the private list so is protected against "external updates".
        // It's much cheaper than .ToList() because it will not have to copy all items in a new collection. (Just one heap alloc for the wrapper instance)
        // List<T>.AsReadOnly Method Docs: https://msdn.microsoft.com/en-us/library/e78dcd75(v=vs.110).aspx 
        public IReadOnlyCollection<CestaItem> Items => _items.AsReadOnly();
        #endregion

        #region Ctor
        public Cesta() { }

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
