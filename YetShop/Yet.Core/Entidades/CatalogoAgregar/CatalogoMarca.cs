namespace Yet.Core.Entidades.CatalogoAgregar
{
    public class CatalogoMarca : EntidadeBase
    {
        #region Campos
        public string Marca { get; private set; }
        #endregion

        #region Ctor
        public CatalogoMarca() { }

        public CatalogoMarca(string marca)
        {
            Marca = marca;
        }
        #endregion
    }
}
