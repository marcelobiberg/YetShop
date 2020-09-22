using System;
using System.Collections.Generic;
using Yet.API.TratamentoBase;
using Yet.Core.Dto.Catalogo;

namespace Yet.API.CatalogoItemEndpoints
{
    public class ListaPaginadaCatalogoItemResponse : BaseResponse
    {
        #region Campos
        public List<CatalogoItemDto> CatalogoItens { get; set; } = new List<CatalogoItemDto>();
        public List<CatalogoMarcaDto> CatalogoMarcas { get; set; } = new List<CatalogoMarcaDto>();
        public List<CatalogoTipoDto> CatalogoTipos { get; set; } = new List<CatalogoTipoDto>();
        public int ContadorPagina { get; set; }
        #endregion

        #region Ctor
        public ListaPaginadaCatalogoItemResponse() { }
        public ListaPaginadaCatalogoItemResponse(Guid correlacaoId) : base(correlacaoId) { }
        #endregion
    }
}
