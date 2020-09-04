using Ardalis.Specification;
using Yet.Core.Entidades.CestaAgregar;

namespace Yet.Core.Especificacoes
{
    public sealed class CestaComItensQuery : Specification<Cesta>
    {
        public CestaComItensQuery(int cestaId)
        {
            Query
                .Where(b => b.Id == cestaId)
                .Include(b => b.Items);
        }

        public CestaComItensQuery(string compradorId)
        {
            Query
                .Where(b => b.CompradorId == compradorId)
                .Include(b => b.Items);
        }
    }
}
