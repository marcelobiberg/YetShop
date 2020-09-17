using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Yet.Core.Dto.Catalogo;
using Yet.Core.Entidades.CatalogoAgregar;
using Yet.Core.Interfaces;

namespace Yet.API.CatalogoTipoEndpoints
{
    public class Lista : BaseAsyncEndpoint<ListaCatalogoTiposResponse>
    {
        #region Campos
        private readonly IRepoAsync<CatalogoTipo> _catalogoTipoRepo;
        private readonly IMapper _mapper;
        #endregion

        #region Ctor
        public Lista(IRepoAsync<CatalogoTipo> catalogoTipoRepo,
            IMapper mapper)
        {
            _catalogoTipoRepo = catalogoTipoRepo;
            _mapper = mapper;
        }
        #endregion

        #region Métodos
        [HttpGet("api/catalogo-tipos")]
        [SwaggerOperation(
            Summary = "Lista com os tipos de itens do catálogo",
            Description = "Lista com os tipos de itens do catálogo",
            OperationId = "catalogo-tipos.List",
            Tags = new[] { "CatalogoTipoEndpoints" })
        ]
        public override async Task<ActionResult<ListaCatalogoTiposResponse>> HandleAsync(CancellationToken cancellationToken)
        {
            var response = new ListaCatalogoTiposResponse();

            var items = await _catalogoTipoRepo.ListAllAsync();

            response.CatalogoTipos.AddRange(items.Select(_mapper.Map<CatalogoTipoDto>));

            return Ok(response);
        }
        #endregion
    }
}
