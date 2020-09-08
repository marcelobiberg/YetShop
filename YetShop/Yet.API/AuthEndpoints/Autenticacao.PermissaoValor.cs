namespace Yet.API.AuthEndpoints
{
    public class PermissaoValor
    {
        #region Ctor
        public PermissaoValor() { }

        public PermissaoValor(string tipo, string valor)
        {
            Tipo = tipo;
            Valor = valor;
        }
        #endregion

        #region Campos
        public string Tipo { get; set; }
        public string Valor { get; set; }
        #endregion
    }
}
