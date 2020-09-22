namespace Yet.Web.ViewModels.Catalogo
{
    public class ModalCatalogoItemViewModel
    {
        #region Campos
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string ImagemUri { get; set; }
        public decimal Preco { get; set; }
        public string MarcaNome { get; set; }
        public string TipoNome { get; set; }
        #endregion
    }
}
