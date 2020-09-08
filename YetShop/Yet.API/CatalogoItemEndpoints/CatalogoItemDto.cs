namespace Yet.API.CatalogoItemEndpoints
{
    public class CatalogoItemDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public string ImagemUri { get; set; }
        public int CatalogoTipoId { get; set; }
        public int CatalogoMarcaId { get; set; }
    }
}
