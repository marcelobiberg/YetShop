using Ardalis.Specification;
using System;
using System.Linq;
using Yet.Core.Entidades.CatalogoAgregar;

namespace Yet.Core.Especificacoes
{
    public class CatalogoItensQuery : Specification<CatalogoItem>
    {
        public CatalogoItensQuery(params int[] ids)
        {
            Query.Where(c => ids.Contains(c.Id));
        }
    }
}
