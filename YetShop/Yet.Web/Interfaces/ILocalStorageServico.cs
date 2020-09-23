using Yet.Web.Models.Autenticacao;

namespace Yet.Web.Interfaces
{
    public interface ILocalStorageServico
    {
        void CacheAutenticacaoResponseLocalAsync(string key, AutenticacaoResponse obj);
        object CacheObterAutenticacaoResponsePorKey(string key);
    }
}
