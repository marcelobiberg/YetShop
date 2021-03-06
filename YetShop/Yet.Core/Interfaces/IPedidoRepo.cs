﻿using System.Threading.Tasks;
using Yet.Core.Entidades.PedidoAgregar;

namespace Yet.Core.Interfaces
{
    /// <summary>
    /// Tasks reponsáveis por manipular o repositório dos pedidos
    /// </summary>
    public interface IPedidoRepo : IRepoAsync<Pedido>
    {
        Task<Pedido> ObterPedidoPorIdAsync(int id);
    }
}
