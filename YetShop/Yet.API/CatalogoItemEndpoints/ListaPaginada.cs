using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Yet.Core.Interfaces;
using Yet.Core.Especificacoes;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Yet.Core.Entidades.CatalogoAgregar;

namespace Yet.API.CatalogoItemEndpoints
{
    public class ListaPaginada : BaseAsyncEndpoint<ListaPaginadaCatalogoItemRequest, ListaPaginadaCatalogoItemResponse>
    {
        #region Campos
        private readonly IRepoAsync<CatalogoItem> _itemRepo;
        private readonly IMapper _mapper;
        #endregion

        #region Ctor
        public ListaPaginada(IRepoAsync<CatalogoItem> itemRepo,
            IMapper mapper)
        {
            _itemRepo = itemRepo;
            _mapper = mapper;
        }
        #endregion

        #region Métodos
        [HttpGet("api/catalogo-itens")]
        [SwaggerOperation(
            Summary = "Lista paginada com itens do catálogo",
            Description = "Lista paginada ( CatalogoItens )",
            OperationId = "catalogo-itens.ListPaged",
            Tags = new[] { "CatalogoItemEndpoints" })
        ]
        public override async Task<ActionResult<ListaPaginadaCatalogoItemResponse>> HandleAsync([FromQuery] ListaPaginadaCatalogoItemRequest request, 
            CancellationToken cancellationToken)
        {
            var response = new ListaPaginadaCatalogoItemResponse(request.CorrelacaoId());

            var filterSpec = new CatalogoFiltroQuery(request.CatalogoMarcaId, request.CatalogoTipoId);
            int totalItems = await _itemRepo.CountAsync(filterSpec);

            var pagedSpec = new CatalogoFiltroPaginacaoQuery(
                skip: request.PageIndex * request.PageSize,
                take: request.PageSize,
                marcaId: request.CatalogoMarcaId,
                tipoId: request.CatalogoTipoId);

            var items = await _itemRepo.ListAsync(pagedSpec);

            response.CatalogoItens.AddRange(items.Select(_mapper.Map<CatalogoItemDto>));
            foreach (CatalogoItemDto item in response.CatalogoItens)
            {
                //TODO: analisar o code abaixo  . . talvez se faça necessário utilizar a classe Uri composer
                //item.PictureUri = _uriComposer.ComposePicUri(item.PictureUri);

                item.ImagemUri = item.ImagemUri;
            }
            response.PageCount = int.Parse(Math.Ceiling((decimal)totalItems / request.PageSize).ToString());

            return Ok(response);
        }
        #endregion
    }
}
