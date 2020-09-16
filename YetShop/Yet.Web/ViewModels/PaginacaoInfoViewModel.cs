namespace Yet.Web.ViewModels
{
    public class PaginacaoInfoViewModel
    {
        public int TotalItens { get; set; }
        public int ItensPorPagina { get; set; }
        public int PaginaAtual { get; set; }
        public int TotalPaginas { get; set; }
        public string Anterior { get; set; }
        public string Proximo { get; set; }
    }
}
