namespace Yet.Core.Entidades.PedidoAgregar
{
    public class Endereco
    {
        #region Campos
        public string Rua { get; private set; }

        public string Cidade { get; private set; }

        public string Estado { get; private set; }

        public string Pais { get; private set; }

        public string Cep { get; private set; }
        #endregion

        #region Ctor
        private Endereco() { }

        public Endereco(string rua, string cidade, string estado, string pais, string cep)
        {
            Rua = rua;
            Cidade = cidade;
            Estado = estado;
            Pais = pais;
            Cep = cep;
        }
        #endregion
    }
}
