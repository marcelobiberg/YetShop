using System.ComponentModel.DataAnnotations;
using Yet.API.TratamentoBase;

namespace Yet.API.CatalogoItemEndpoints
{
    public class AtualizaCatalogoItemRequest : BaseRequest
    {
        #region Campos
        [Range(1, 10000)]
        public int Id { get; set; }
        [Range(1, 10000)]
        public int CatalogMarcaId { get; set; }
        [Range(1, 10000)]
        public int CatalogTipoId { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public string Nome { get; set; }
        public string ImagemBase64 { get; set; }
        public string ImagemUri { get; set; }
        public string ImagemNome { get; set; }
        [Range(0.01, 10000)]
        public decimal Preco { get; set; }
        #endregion
    }
}
