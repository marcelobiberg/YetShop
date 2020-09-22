using Ardalis.Specification;
using Yet.Core.Entidades.CatalogoAgregar;

namespace Yet.Core.Especificacoes
{
    public class CatalogoItemQuery : Specification<CatalogoItem>
    {
        /// <summary>
        /// Monta a query do catálogo item e seus relacionamentos com Marcas & Tipos
        /// </summary>
        /// <param name="catalogoitemId">Id do item</param>
        public CatalogoItemQuery(int catalogoitemId)
        {
            Query
                .Where(ci => ci.Id == catalogoitemId);
        }
    }
}
