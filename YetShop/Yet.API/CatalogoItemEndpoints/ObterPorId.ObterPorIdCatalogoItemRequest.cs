using Yet.API.TratamentoBase;

namespace Yet.API.CatalogoItemEndpoints
{
    public class ObterPorIdCatalogoItemRequest : BaseRequest 
    {
        public int CatalogoItemId { get; set; }
    }
}
