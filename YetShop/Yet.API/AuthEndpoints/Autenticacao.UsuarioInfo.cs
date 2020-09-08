using System.Collections.Generic;

namespace Yet.API.AuthEndpoints
{
    public class UsuarioInfo
    {
        public static readonly UsuarioInfo Anonymous = new UsuarioInfo();
        public bool Autenticado { get; set; }
        public string PermissaoNomeTipo { get; set; }
        public string PermissaoPerfilTipo { get; set; }
        public IEnumerable<PermissaoValor> Permissoes { get; set; }
    }
}
