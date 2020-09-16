using Refit;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yet.Shared.Models;

namespace Yet.Shared.Interfaces
{
    public interface ICatalogoItemServico
    {
        [Get("/api/catalogo-itens-paginado")]
        Task<List<ListaCatalogoItensViewModel>> ListaPaginada(int? paginaId, int itensPorPagina, int? marcaId, int? tipoId);
    }
}
