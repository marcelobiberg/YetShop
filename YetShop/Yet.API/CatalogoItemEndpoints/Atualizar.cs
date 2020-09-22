using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Yet.Core.Constantes;
using Yet.Core.Dto.Catalogo;
using Yet.Core.Entidades.CatalogoAgregar;
using Yet.Core.Interfaces;

namespace Yet.API.CatalogoItemEndpoints
{
    [Authorize(Roles = Autenticacao.PERFIL_ADMINISTRADOR, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class Atualizar : BaseAsyncEndpoint<AtualizaCatalogoItemRequest, AtualizaCatalogoItemResponse>
    {
        #region Campos
        private readonly IRepoAsync<CatalogoItem> _catalogoItemRepo;
        private readonly IArquivo _arquivo;
        #endregion

        #region Ctor
        public Atualizar(IRepoAsync<CatalogoItem> itemRepo,
            IArquivo arquivo)
        {
            _catalogoItemRepo = itemRepo;
            _arquivo = arquivo;

        }
        #endregion

        #region Métodos
        [HttpPut("api/catalogo-item-update")]
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

            var catalogoItem = await _catalogoItemRepo.GetByIdAsync(request.Id);

            catalogoItem.AtualizaDetalhes(request.Nome, request.Descricao, request.Preco);
            catalogoItem.AtualizaMarca(request.CatalogMarcaId);
            catalogoItem.AtualizaTipo(request.CatalogTipoId);

            if (string.IsNullOrEmpty(request.ImagemBase64) && string.IsNullOrEmpty(request.ImagemUri))
            {
                catalogoItem.AtualizaImagemUri(string.Empty);
            }
            else
            {
                var picName = $"{catalogoItem.Id}{Path.GetExtension(request.ImagemNome)}";
                if (await _arquivo.SalvarImagem($"{picName}", request.ImagemBase64))
                {
                    catalogoItem.AtualizaImagemUri(picName);
                }
            }

            await _catalogoItemRepo.UpdateAsync(catalogoItem);

            var dto = new CatalogoItemDto
            {
                Id = catalogoItem.Id,
                CatalogoMarcaId = catalogoItem.CatalogoMarcaId,
                CatalogoTipoId = catalogoItem.CatalogoTipoId,
                Descricao = catalogoItem.Descricao,
                Nome = catalogoItem.Nome,
                ImagemUri = catalogoItem.ImagemUri,
                Preco = catalogoItem.Preco
            };
            response.CatalogoItem = dto;
            return response;
        }
        #endregion
    }
}
