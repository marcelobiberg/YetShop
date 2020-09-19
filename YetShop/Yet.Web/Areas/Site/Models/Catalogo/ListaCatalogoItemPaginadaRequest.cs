namespace Yet.Web.Areas.Site.Models.Catalogo
{
    public class ListaCatalogoItemPaginadaRequest
    {
        public byte TamanhoPagina { get; set; }
        public byte IndicePagina { get; set; }
        public uint? CatalogoMarcaId { get; set; }
        public uint? CatalogoTipoId { get; set; }
    }
}
