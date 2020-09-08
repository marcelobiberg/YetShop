using Yet.API.TratamentoBase;

namespace Yet.API.CatalogoItemEndpoints
{
    public class AdicionaCatalogoItemRequest : BaseRequest
    {
        #region Campos
        public int CatalogoMarcaId { get; set; }
        public int CatalogoTipoId { get; set; }
        public string Descricao { get; set; }
        public string Nome { get; set; }
        public string ImagemUri { get; set; }
        public string ImagemBase64 { get; set; }
        public string ImagemNome { get; set; }
        public decimal Preco { get; set; }
        #endregion
    }
}
