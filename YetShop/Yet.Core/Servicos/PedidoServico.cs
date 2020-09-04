using Ardalis.GuardClauses;
using System.Linq;
using System.Threading.Tasks;
using Yet.Core.Entidades.CatalogoAgregar;
using Yet.Core.Entidades.CestaAgregar;
using Yet.Core.Entidades.PedidoAgregar;
using Yet.Core.Especificacoes;
using Yet.Core.Interfaces;

namespace Yet.Core.Servicos
{
    /// <summary>
    /// Objeto responsável pela manipulação dos serviços do pedido
    /// </summary>
    public class PedidoServico : IPedidoServico
    {
        #region Campos
        private readonly IRepoAsync<Pedido> _pedidoRepo;
        private readonly IRepoAsync<Cesta> _cestaRepo;
        private readonly IRepoAsync<CatalogoItem> _catalogoItemRepo;
        #endregion

        #region Ctor

        public PedidoServico() { }

        public PedidoServico(IRepoAsync<Cesta> cestaRepo,
            IRepoAsync<CatalogoItem> catalogoItemRepo,
            IRepoAsync<Pedido> pedidoRepo)
        {
            _pedidoRepo = pedidoRepo;
            _cestaRepo = cestaRepo;
            _catalogoItemRepo = catalogoItemRepo;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Cria o pedido com os itens da carrinho de compras ( Cesta )
        /// </summary>
        /// <param name="cestaId">ID da cesta</param>
        /// <param name="enderecoEntrega">Endereço de entrega do pedido</param>
        public async Task CriarPedidoAsync(int cestaId, Endereco enderecoEntrega)
        {
            //Query com as especificações para o objeto ( Cesta ) e busca os dados no repo
            var cestaQuery = new CestaComItensQuery(cestaId);
            var cesta = await _cestaRepo.FirstOrDefaultAsync(cestaQuery);

            //Valida se a cesta não é null e não esta vazia
            Guard.Against.NullCesta(cestaId, cesta);
            Guard.Against.CestaVaziaAoFinalizar(cesta.Items);

            //Ids dos itens do catálogo
            var catalogoItensIds = cesta.Items.Select(item => item.CatalogoItemId).ToArray();

            //Cria a query com os Ids dos itens do catálodo na cesta e busca no repo
            //TODO: verificar a lógica e ajsutar a docuemntação se necessário
            var catalogoItensQuery = new CatalogoItensQuery(catalogoItensIds);
            var catalogoItens = await _catalogoItemRepo.ListAsync(catalogoItensQuery);


            var items = cesta.Items.Select(cestaItem =>
            {
                var catalogoItem = catalogoItens.First(c => c.Id == cestaItem.CatalogoItemId);
                var itensSolicitados = new CatalogoItemPedido(catalogoItem.Id, catalogoItem.Nome);
                var pedidoItem = new PedidoItem(itensSolicitados, cestaItem.PrecoUnit, cestaItem.Quantidade);
                return pedidoItem;
            }).ToList();

            var pedido = new Pedido(cesta.CompradorId, enderecoEntrega, items);

            await _pedidoRepo.AddAsync(pedido);
        }
        #endregion
    }
}
