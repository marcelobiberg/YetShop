using Ardalis.Specification;
using Yet.Core.Entidades.CatalogoAgregar;

namespace Yet.Core.Especificacoes
{
    public class CatalogoFiltroQuery : Specification<CatalogoItem>
    {
        public CatalogoFiltroQuery(int? marcaId, int? tipoId)
        {
            Query.Where(i => (!marcaId.HasValue || i.CatalogoMarcaId == marcaId) &&
                (!tipoId.HasValue || i.CatalogoTipoId == tipoId));
        }
    }
}
