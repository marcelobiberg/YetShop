using Yet.API.TratamentoBase;

namespace Yet.API.CatalogoItemEndpoints
{
    public class ListaPaginadaCatalogoItemRequest : BaseRequest
    {
        #region Campos
        public byte TamanhoPagina { get; set; }
        public byte IndicePagina { get; set; }
        public uint? CatalogoMarcaId { get; set; }
        public uint? CatalogoTipoId { get; set; }
        #endregion
    }
}
