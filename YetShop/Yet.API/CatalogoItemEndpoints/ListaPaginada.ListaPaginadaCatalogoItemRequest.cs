using Yet.API.TratamentoBase;

namespace Yet.API.CatalogoItemEndpoints
{
    public class ListaPaginadaCatalogoItemRequest : BaseRequest
    {
        #region Campos
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public int? CatalogoMarcaId { get; set; }
        public int? CatalogoTipoId { get; set; }
        #endregion
    }
}
