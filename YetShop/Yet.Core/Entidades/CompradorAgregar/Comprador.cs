using Ardalis.GuardClauses;

namespace Yet.Core.Entidades.CompradorAgregar
{
    class Comprador
    {
        #region Campos
        public string IdentityGuid { get; private set; }
        #endregion

        #region Ctor
        private Comprador() { }

        public Comprador(string identity) : this()
        {
            Guard.Against.NullOrEmpty(identity, nameof(identity));
            IdentityGuid = identity;
        }
        #endregion
    }
}
