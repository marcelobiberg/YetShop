using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Yet.Core.Entidades;
using Yet.Core.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Yet.Core.Entidades.CatalogoAgregar;

namespace Yet.API.CatalogoMarcaEndpoints
{
    public class Lista : BaseAsyncEndpoint<ListaCatalogoMarcasResponse>
    {
        #region Campos
        private readonly IRepoAsync<CatalogoMarca> _catalogoMarcaRepo;
        private readonly IMapper _mapper;
        #endregion

        #region Ctor
        public Lista(IRepoAsync<CatalogoMarca> catalogoMarcaRepo,
            IMapper mapper)
        {
            _catalogoMarcaRepo = catalogoMarcaRepo;
            _mapper = mapper;
        }
        #endregion

        #region Métodos
        [HttpGet("api/catalog-brands")]
        [SwaggerOperation(
            Summary = "List Catalog Brands",
            Description = "List Catalog Brands",
            OperationId = "catalog-brands.List",
            Tags = new[] { "CatalogBrandEndpoints" })
        ]
        public override async Task<ActionResult<ListaCatalogoMarcasResponse>> HandleAsync(CancellationToken cancellationToken)
        {
            var response = new ListaCatalogoMarcasResponse();

            var items = await _catalogoMarcaRepo.ListAllAsync();

            response.CatalogoMarcas.AddRange(items.Select(_mapper.Map<CatalogoMarcaDto>));

            return Ok(response);
        }
        #endregion
    }
}
