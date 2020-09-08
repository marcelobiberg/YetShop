using Yet.API.TratamentoBase;

namespace Yet.API.CatalogoItemEndpoints
{
    public class DeletaCatalogoItemRequest : BaseRequest
    {
        public int CatalogoItemId { get; set; }
    }
}
