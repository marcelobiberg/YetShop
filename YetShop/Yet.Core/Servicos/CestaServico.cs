using Ardalis.GuardClauses;
using System.Collections.Generic;
using System.Threading.Tasks;
using Yet.Core.Entidades.CestaAgregar;
using Yet.Core.Especificacoes;
using Yet.Core.Interfaces;

namespace Yet.Core.Servicos
{
    /// <summary>
    /// Objeto responsável pela manipulação dos serviços do carrinho de compras ( Cesta )
    /// </summary>
    public class CestaServico : ICestaServico
    {
        #region Campos
        private readonly IRepoAsync<Cesta> _cestaRepo;
        private readonly IAppLogger<CestaServico> _logger;
        #endregion

        #region Ctor
        public CestaServico() { }
        public CestaServico(IRepoAsync<Cesta> cestaRepo,
            IAppLogger<CestaServico> logger)
        {
            _cestaRepo = cestaRepo;
            _logger = logger;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Adiciona item ao corrinho de compras ( Cesta )
        /// </summary>
        /// <param name="cestaId">ID da cesta</param>
        /// <param name="catalogoItemId">ID do item do catálogo</param>
        /// <param name="preco">Preço do item</param>
        /// <param name="quantidade">Quantidade do item</param>
        public async Task AdicionarItemParaCestaAsync(int cestaId, int catalogoItemId, decimal preco, int quantidade = 1)
        {
            //Query com as especificações para o objeto ( Cesta ) e busca os dados no repo
            var cestaQuery = new CestaComItensQuery(cestaId);
            var cesta = await _cestaRepo.FirstOrDefaultAsync(cestaQuery);

            // . . Valida as assinaturas do método se != null
            Guard.Against.NullCesta(cestaId, cesta);

            // . . Adiciona o item a cesta
            cesta.AdicionarItem(catalogoItemId, preco, quantidade);

            // . . Atualiza o modelo
            await _cestaRepo.UpdateAsync(cesta);
        }

        /// <summary>
        /// Remove item do carrinho de compras( Cesta )
        /// </summary>
        /// <param name="cestaId">ID da cesta</param>
        public async Task RemoveCestaAsync(int cestaId)
        {
            var cesta = await _cestaRepo.GetByIdAsync(cestaId);
            await _cestaRepo.DeleteAsync(cesta);
        }

        /// <summary>
        /// Setta a quantidade de itens na cesta
        /// </summary>
        /// <param name="cestaId">ID da cesta</param>
        /// <param name="quantidades">Quantidades dos itens</param>
        public async Task SetQuantidadesAsync(int cestaId, Dictionary<string, int> quantidades)
        {
            //valida assinatura quantidades
            Guard.Against.Null(quantidades, nameof(quantidades));

            //Query com as especificações para o objeto ( Cesta ) e busca os dados no repo
            var cestaQuery = new CestaComItensQuery(cestaId);
            var cesta = await _cestaRepo.FirstOrDefaultAsync(cestaQuery);

            //Valida o objeto ( Cesta )
            Guard.Against.NullCesta(cestaId, cesta);

            foreach (var item in cesta.Items)
            {
                if (quantidades.TryGetValue(item.Id.ToString(), out var quantidade))
                {
                    if (_logger != null) _logger.LogInformation($"Atualizada a quantidade do item ID:{item.Id} para {quantidade}.");
                    item.SetQuantidade(quantidade);
                }
            }

            //Remove itens com qtd == 0 e atualiza o repo
            cesta.RemoveItensVazios();
            await _cestaRepo.UpdateAsync(cesta);
        }

        /// <summary>
        /// Setta a quantidade de itens na cesta
        /// </summary>
        /// <param name="anonimoId">ID da cesta anônima</param>
        /// <param name="userNome">Nome do usuário</param>
        public async Task TransferirCestaAsync(string anonimoId, string userNome)
        {
            //valida as assinaturas
            Guard.Against.NullOrEmpty(anonimoId, nameof(anonimoId));
            Guard.Against.NullOrEmpty(userNome, nameof(userNome));

            //Query com as especificações para o objeto ( Cesta ) e busca os dados no repo
            var AnonimoCestaQuery = new CestaComItensQuery(anonimoId);
            var anonimoCesta = await _cestaRepo.FirstOrDefaultAsync(AnonimoCestaQuery);

            //Se não encontrar sai do método
            if (anonimoCesta == null) return;

            //Query com as especificações para o objeto ( Cesta ) e busca os dados no repo
            var usuarioCestaQuery = new CestaComItensQuery(userNome);
            var usuarioCesta = await _cestaRepo.FirstOrDefaultAsync(usuarioCestaQuery);

            //Valida se existe cesta do usuário no repo
            if (usuarioCesta == null)
            {
                //. . Cria uma nova cesta e adiciona ao repo do modelo
                usuarioCesta = new Cesta(userNome);
                await _cestaRepo.AddAsync(usuarioCesta);
            }

            //Transfere do repo anonimoCesta para usuarioCesta 
            foreach (var item in anonimoCesta.Items)
            {
                usuarioCesta.AdicionarItem(item.CatalogoItemId, item.PrecoUnit, item.Quantidade);
            }

            //Atualiza o repo do usuário
            await _cestaRepo.UpdateAsync(usuarioCesta);

            //Remove a cesta anônima
            await _cestaRepo.DeleteAsync(anonimoCesta);
        }
    }
    #endregion
}
