using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;
using Yet.Core.Dto.Catalogo;
using Yet.Core.Entidades.CatalogoAgregar;
using Yet.Core.Interfaces;

namespace Yet.API.CatalogoItemEndpoints
{
    public class ObterPorId : BaseAsyncEndpoint<ObterPorIdCatalogoItemRequest, ObterPorIdCatalogoItemResponse>
    {
        #region Campos
        private readonly IRepoAsync<CatalogoItem> _catalogoItemRepo;
        private readonly IRepoAsync<CatalogoMarca> _catalogoItemMarcaRepo;
        private readonly IRepoAsync<CatalogoTipo> _catalogoItemTipoRepo;
        #endregion

        #region Ctor
        public ObterPorId(IRepoAsync<CatalogoItem> itemRepo,
            IRepoAsync<CatalogoMarca> catalogoMarca,
            IRepoAsync<CatalogoTipo> catalogoTipo)
        {
            _catalogoItemRepo = itemRepo;
            _catalogoItemMarcaRepo = catalogoMarca;
            _catalogoItemTipoRepo = catalogoTipo;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Método responsável por retornar o DTO do catálogo item
        /// </summary>
        /// <param name="request">Objeto com as informaçõs do request ( CatalogoItemId )</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("api/catalogo-item/{CatalogoItemId}")]
        [SwaggerOperation(
            Summary = "Obtém um item do catálogo pelo Id",
            Description = "Obtém um item do catálogo pelo Id",
            OperationId = "catalogo-itens.GetById",
            Tags = new[] { "CatalogoItemEndpoints" })
        ]
        public override async Task<ActionResult<ObterPorIdCatalogoItemResponse>> HandleAsync([FromRoute] ObterPorIdCatalogoItemRequest request,
            CancellationToken cancellationToken)
        {
            // Instancia o objeto ( response ) settando o id de relação do request
            var response = new ObterPorIdCatalogoItemResponse(request.CorrelacaoId());

            // Busca no repositório os itens do catálogo, catálogo marcas e catálogo tipos ( categorias ) 
            var catalogoItem = await _catalogoItemRepo.
                GetByIdAsync(request.CatalogoItemId);
            var catalogoMarca = await _catalogoItemMarcaRepo
                .GetByIdAsync(catalogoItem.CatalogoMarcaId);
            var catalogoTipo = await _catalogoItemTipoRepo
                .GetByIdAsync(catalogoItem.CatalogoTipoId);

            // Valida os objetos
            if (catalogoItem is null) return NotFound();
            if (catalogoMarca is null) return NotFound();
            if (catalogoTipo is null) return NotFound();

            // Popula o objeto response com as informações dos repos
            response.CatalogoItem = new CatalogoItemDto
            {
                Id = catalogoItem.Id,
                CatalogoMarcaId = catalogoItem.CatalogoMarcaId,
                CatalogoTipoId = catalogoItem.CatalogoTipoId,
                Descricao = catalogoItem.Descricao,
                Nome = catalogoItem.Nome,
                ImagemUri = catalogoItem.ImagemUri,
                Preco = catalogoItem.Preco
            };
            response.CatalogoMarcaNome = catalogoMarca.Marca;
            response.CatalogoTipoNome = catalogoTipo.Tipo;

            return Ok(response);
        }
    }
    #endregion
}
