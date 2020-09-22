using Yet.Web.Dto.Catalogo;

namespace Yet.Web.Models.Catalogo
{
    public class ObterCatalogoItemPorIdResponse
    {
        public CatalogoItemDto CatalogoItem { get; set; }
        public string CatalogoMarcaNome { get; set; }
        public string CatalogoTipoNome { get; set; }
    }
}
