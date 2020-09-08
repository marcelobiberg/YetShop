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
    public class Adicionar : BaseAsyncEndpoint<AdicionaCatalogoItemRequest, AdicionaCatalogoItemResponse>
    {
        #region Campos
        private readonly IRepoAsync<CatalogoItem> _itemRepo;
        private readonly IFileSystem _webFileSystem;
        #endregion

        #region Ctor
        public Adicionar(IRepoAsync<CatalogoItem> itemRepo, IFileSystem webFileSystem)
        {
            _itemRepo = itemRepo;
            _webFileSystem = webFileSystem;
        }
        #endregion

        #region Métodos
        [HttpPost("api/catalogo-itens")]
        [SwaggerOperation(
            Summary = " Cria um novo item de catálogo",
            Description = "Cria um novo item de catálogo",
            OperationId = "catalogo-itens.create",
            Tags = new[] { "CatalogoItemEndpoints" })
        ]
        public override async Task<ActionResult<AdicionaCatalogoItemResponse>> HandleAsync(AdicionaCatalogoItemRequest request,
            CancellationToken cancellationToken)
        {
            var response = new AdicionaCatalogoItemResponse(request.CorrelacaoId());

            var newItem = new CatalogoItem(request.CatalogoTipoId,
                request.CatalogoMarcaId,
                request.Descricao,
                request.Nome,
                request.Preco,
                request.ImagemUri);

            newItem = await _itemRepo.AddAsync(newItem);

            if (newItem.Id != 0)
            {
                var picName = $"{newItem.Id}{Path.GetExtension(request.ImagemNome)}";
                if (await _webFileSystem.SavePicture(picName, request.ImagemBase64))
                {
                    newItem.ImagemUriUpdate(picName);
                    await _itemRepo.UpdateAsync(newItem);
                }
            }

            var dto = new CatalogoItemDto
            {
                Id = newItem.Id,
                CatalogoMarcaId = newItem.CatalogoMarcaId,
                CatalogoTipoId = newItem.CatalogoTipoId,
                Descricao = newItem.Descricao,
                Nome = newItem.Nome,
                ImagemUri = newItem.ImagemUri,
                Preco = newItem.Preco
            };
            response.CatalogoItem = dto;
            return response;
        }
        #endregion
    }
}
