namespace Yet.Core.Entidades.CatalogoAgregar
{
    public class CatalogoTipo : EntidadeBase
    {
        #region Campos
        public string Tipo { get; private set; }
        #endregion

        #region Ctor
        public CatalogoTipo(string tipo)
        {
            Tipo = tipo;
        }
        #endregion
    }
}
