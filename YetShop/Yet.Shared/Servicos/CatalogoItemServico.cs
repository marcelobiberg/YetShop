using Refit;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Yet.Shared.Interfaces;
using Yet.Shared.Models;

namespace Yet.Shared.Servicos
{
    public class CatalogoItemServico : ICatalogoItemServico
    {
        public async Task<List<CatalogoItem>> ListaPaginada(int? paginaId, int itensPorPagina, int? marcaId, int? tipoId)
        {
            var catalogoItensClient = RestService.For<ICatalogoItemServico>("https://localhost:44307/");

            var listaPaginada = await catalogoItensClient.ListaPaginada(paginaId, itensPorPagina, marcaId, tipoId);

            return listaPaginada;
        }
    }
}
