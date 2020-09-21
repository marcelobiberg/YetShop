using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Yet.Core.Entidades.CatalogoAgregar;
using Yet.Core.Interfaces;

namespace Yet.Infrastructure.Data
{
    public class CatalogoRepo : EfRepo<CatalogoItem>, ICatalogoRepo
    {
        public CatalogoRepo(CatalogoContexto dbContext) : base(dbContext) { }

        public async Task<CatalogoItem> ObterCatalogoItemPorIdAsync(int id)
        {
            return await _dbContext
                .CatalogoItens
                .Include(m => m.CatalogoMarca)
                .Include(t => t.CatalogoTipo)
                .FirstOrDefaultAsync(ci => ci.Id == id);
        }
    }
}
