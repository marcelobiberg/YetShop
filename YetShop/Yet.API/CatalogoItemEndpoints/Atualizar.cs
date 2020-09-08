using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Yet.Core.Constantes;
using Yet.Core.Entidades.CatalogoAgregar;
using Yet.Core.Interfaces;

namespace Yet.API.CatalogoItemEndpoints
{
    [Authorize(Roles = Autenticacao.PERFIL_ADMINISTRADOR, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class Atualizar : BaseAsyncEndpoint<AtualizaCatalogoItemRequest, AtualizaCatalogoItemResponse>
    {
        #region Campos
        private readonly IRepoAsync<CatalogoItem> _catalogoItemRepo;
        private readonly IFileSystem _webFileSystem;
        #endregion

        #region Ctor
        public Atualizar(IRepoAsync<CatalogoItem> itemRepo,
            IFileSystem webFileSystem)
        {
            _catalogoItemRepo = itemRepo;
            _webFileSystem = webFileSystem;

        }
        #endregion

        #region Métodos
        [HttpPut("api/catalogo-itens")]
        [SwaggerOperation(
            Summary = "Atualiza um item do catálogo",
            Description = "Atualiza um item do catálogo",
            OperationId = "catalogo-itens.update",
            Tags = new[] { "CatalogoItemEndpoints" })
        ]
        public override async Task<ActionResult<AtualizaCatalogoItemResponse>> HandleAsync(AtualizaCatalogoItemRequest request,
            CancellationToken cancellationToken)
        {
            var response = new AtualizaCatalogoItemResponse(request.CorrelacaoId());

            var existingItem = await _catalogoItemRepo.GetByIdAsync(request.Id);

            existingItem.DetalhesUpdate(request.Nome, request.Descricao, request.Preco);
            existingItem.MarcaUpdate(request.CatalogMarcaId);
            existingItem.TipoUpdate(request.CatalogTipoId);

            if (string.IsNullOrEmpty(request.ImagemBase64) && string.IsNullOrEmpty(request.ImagemUri))
            {
                existingItem.ImagemUriUpdate(string.Empty);
            }
            else
            {
                var picName = $"{existingItem.Id}{Path.GetExtension(request.ImagemNome)}";
                if (await _webFileSystem.SavePicture($"{picName}", request.ImagemBase64))
                {
                    existingItem.ImagemUriUpdate(picName);
                }
            }

            await _catalogoItemRepo.UpdateAsync(existingItem);

            var dto = new CatalogoItemDto
            {
                Id = existingItem.Id,
                CatalogoMarcaId = existingItem.CatalogoMarcaId,
                CatalogoTipoId = existingItem.CatalogoTipoId,
                Descricao = existingItem.Descricao,
                Nome = existingItem.Nome,
                ImagemUri = existingItem.ImagemUri,
                Preco = existingItem.Preco
            };
            response.CatalogoItem = dto;
            return response;
        }
        #endregion
    }
}
