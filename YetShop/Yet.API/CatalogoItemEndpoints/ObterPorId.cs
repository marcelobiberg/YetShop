using Ardalis.ApiEndpoints;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using Yet.Core.Dto.Catalogo;
using Yet.Core.Interfaces;

namespace Yet.API.CatalogoItemEndpoints
{
    public class ObterPorId : BaseAsyncEndpoint<ObterPorIdCatalogoItemRequest, ObterPorIdCatalogoItemResponse>
    {
        #region Campos
        private readonly ICatalogoRepo _catalogoRepo;
        #endregion

        #region Ctor
        public ObterPorId(ICatalogoRepo catalogoRepo)
        {
            _catalogoRepo = catalogoRepo;
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
            var catalogoItem = await _catalogoRepo
                .ObterCatalogoItemPorIdAsync(request.CatalogoItemId);
            if (catalogoItem is null) return NotFound();

            // Popula o objeto 'response' com o retorno do repo e seus ralacionamentos
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
            response.CatalogoMarcaNome = catalogoItem.CatalogoMarca.Marca;
            response.CatalogoTipoNome = catalogoItem.CatalogoTipo.Tipo;

            return Ok(response);
        }
    }
    #endregion
}
