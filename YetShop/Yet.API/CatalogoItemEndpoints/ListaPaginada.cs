using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Yet.Core.Dto.Catalogo;
using Yet.Core.Entidades.CatalogoAgregar;
using Yet.Core.Especificacoes;
using Yet.Core.Interfaces;

namespace Yet.API.CatalogoItemEndpoints
{
    [AllowAnonymous]
    public class ListaPaginada : BaseAsyncEndpoint<ListaPaginadaCatalogoItemRequest, ListaPaginadaCatalogoItemResponse>
    {
        #region Campos
        private readonly IRepoAsync<CatalogoItem> _catalogoItemRepo;
        private readonly IRepoAsync<CatalogoTipo> _catalogoTipoRepo;
        private readonly IRepoAsync<CatalogoMarca> _catalogoMarcaRepo;
        private readonly IMapper _mapper;
        #endregion

        #region Ctor
        public ListaPaginada(IRepoAsync<CatalogoItem> catalogoItem,
            IRepoAsync<CatalogoMarca> catalogoMarca,
            IRepoAsync<CatalogoTipo> catalogoTipo,
            IMapper mapper)
        {
            _catalogoItemRepo = catalogoItem;
            _catalogoMarcaRepo = catalogoMarca;
            _catalogoTipoRepo = catalogoTipo;
            _mapper = mapper;
        }
        #endregion

        #region Métodos
        [HttpGet("api/catalogo-itens-paginado")]
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
            int totalItems = await _catalogoItemRepo.CountAsync(filterSpec);

            var pagedSpec = new CatalogoFiltroPaginacaoQuery(
                skip: request.IndicePagina * request.TamanhoPagina,
                take: request.TamanhoPagina,
                marcaId: request.CatalogoMarcaId,
                tipoId: request.CatalogoTipoId);

            var items = await _catalogoItemRepo.ListAsync(pagedSpec);

            response.CatalogoItens.AddRange(items.Select(_mapper.Map<CatalogoItemDto>));
            foreach (CatalogoItemDto item in response.CatalogoItens)
            {
                //TODO: analisar o code abaixo  . . talvez se faça necessário utilizar a classe Uri composer
                //item.PictureUri = _uriComposer.ComposePicUri(item.PictureUri);
                item.ImagemUri = item.ImagemUri;
            }

            var marcas = await _catalogoMarcaRepo.ListAllAsync();
            var tipos = await _catalogoTipoRepo.ListAllAsync();

            response.CatalogoMarcas.AddRange(marcas.Select(_mapper.Map<CatalogoMarcaDto>));
            response.CatalogoTipos.AddRange(tipos.Select(_mapper.Map<CatalogoTipoDto>));

            response.ContadorPagina = int.Parse(Math.Ceiling((decimal)totalItems / request.TamanhoPagina).ToString());

            return Ok(response);
        }
        #endregion
    }
}
