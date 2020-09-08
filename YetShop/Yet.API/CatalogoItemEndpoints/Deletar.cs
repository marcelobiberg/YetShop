using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading;
using System.Threading.Tasks;
using Yet.Core.Constantes;
using Yet.Core.Entidades.CatalogoAgregar;
using Yet.Core.Interfaces;

namespace Yet.API.CatalogoItemEndpoints
{
    [Authorize(Roles = Autenticacao.PERFIL_ADMINISTRADOR, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class Deletar : BaseAsyncEndpoint<DeletaCatalogoItemRequest, DeletaCatalogoItemResponse>
    {
        #region Campos
        private readonly IRepoAsync<CatalogoItem> _itemRepo;
        #endregion

        #region Ctor
        public Deletar(IRepoAsync<CatalogoItem> itemRepo)
        {
            _itemRepo = itemRepo;
        }
        #endregion

        #region Métodos
        [HttpDelete("api/catalogo-itens/{CatalogoItemId}")]
        [SwaggerOperation(
            Summary = "Remove um item do catálago",
            Description = "Remove um item do catálago",
            OperationId = "catalogo-itens.Delete",
            Tags = new[] { "CatalogoItemEndpoints" })
        ]
        public override async Task<ActionResult<DeletaCatalogoItemResponse>> HandleAsync([FromRoute] DeletaCatalogoItemRequest request,
            CancellationToken cancellationToken)
        {
            var response = new DeletaCatalogoItemResponse(request.CorrelacaoId());

            var itemToDelete = await _itemRepo.GetByIdAsync(request.CatalogoItemId);
            if (itemToDelete is null) return NotFound();

            await _itemRepo.DeleteAsync(itemToDelete);

            return Ok(response);
        }
        #endregion
    }
}
