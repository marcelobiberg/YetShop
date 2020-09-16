using Ardalis.Specification;
using Yet.Core.Entidades.CatalogoAgregar;

namespace Yet.Core.Especificacoes
{
    public class CatalogoFiltroPaginacaoQuery : Specification<CatalogoItem>
    {
        public CatalogoFiltroPaginacaoQuery(int skip, int take, uint? marcaId, uint? tipoId)
            : base()
        {
            Query
                .Where(i => (!marcaId.HasValue || i.CatalogoMarcaId == marcaId) &&
                (!tipoId.HasValue || i.CatalogoTipoId == tipoId))
                .Paginate(skip, take);
        }
    }
}
