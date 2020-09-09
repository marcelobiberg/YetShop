namespace Yet.Infrastructure.Data
{
    public class ArquivoItem
    {
        public string ArquivoNome { get; set; }
        public string Url { get; set; }
        public long Tamanho { get; set; }
        public string Extensao { get; set; }
        public string Tipo { get; set; }
        public string ArquivoNaBase64 { get; set; }
    }
}