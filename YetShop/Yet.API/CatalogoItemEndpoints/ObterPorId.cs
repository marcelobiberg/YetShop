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
        private readonly IRepoAsync<CatalogoItem> _itemRepo;
        #endregion

        #region Ctor
        public ObterPorId(IRepoAsync<CatalogoItem> itemRepo)
        {
            _itemRepo = itemRepo;
        }
        #endregion

        #region Métodos
        [HttpGet("api/catalogo-itens/{CatalogoItemId}")]
        [SwaggerOperation(
            Summary = "Obtém um item do catálogo pelo Id",
            Description = "Obtém um item do catálogo pelo Id",
            OperationId = "catalogo-itens.GetById",
            Tags = new[] { "CatalogoItemEndpoints" })
        ]
        public override async Task<ActionResult<ObterPorIdCatalogoItemResponse>> HandleAsync([FromRoute] ObterPorIdCatalogoItemRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ObterPorIdCatalogoItemResponse(request.CorrelacaoId());

            var item = await _itemRepo.GetByIdAsync(request.CatalogoItemId);
            if (item is null) return NotFound();

            response.CatalogoItem = new CatalogoItemDto
            {
                Id = item.Id,
                CatalogoMarcaId = item.CatalogoMarcaId,
                CatalogoTipoId = item.CatalogoTipoId,
                Descricao = item.Descricao,
                Nome = item.Nome,
                ImagemUri = item.ImagemUri,
                Preco = item.Preco
            };
            return Ok(response);
        }
    }
    #endregion
}
