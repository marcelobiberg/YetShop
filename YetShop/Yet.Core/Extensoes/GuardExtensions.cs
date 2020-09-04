using System.Collections.Generic;
using System.Linq;
using Yet.Core.Entidades.CestaAgregar;
using Yet.Core.Excecoes;

namespace Ardalis.GuardClauses
{
    public static class CestaGuards
    {
        public static void NullCesta(this IGuardClause guardClause, int cestatId, Cesta cesta)
        {
            if (cesta == null)
                throw new CestaNotFoundException(cestatId);
        }

        public static void CestaVaziaAoFinalizar(this IGuardClause guardClause, IReadOnlyCollection<CestaItem> itensCesta)
        {
            if (!itensCesta.Any())
                throw new CestaVaziaAoFinalizarException();
        }
    }
}