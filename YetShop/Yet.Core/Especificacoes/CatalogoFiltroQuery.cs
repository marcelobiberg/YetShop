using Ardalis.Specification;
using Yet.Core.Entidades.CatalogoAgregar;

namespace Yet.Core.Especificacoes
{
    public class CatalogoFiltroQuery : Specification<CatalogoItem>
    {
        public CatalogoFiltroQuery(uint? marcaId, uint? tipoId)
        {
            Query.Where(i => (!marcaId.HasValue || i.CatalogoMarcaId == marcaId) &&
                (!tipoId.HasValue || i.CatalogoTipoId == tipoId));
        }
    }
}
