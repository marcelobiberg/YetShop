using Hanssens.Net;
using Yet.Web.Interfaces;
using Yet.Web.Models.Autenticacao;

namespace Yet.Web.Servicos
{
    public class LocalStorageServico : ILocalStorageServico
    {
        #region Campos
        private LocalStorage _localStorage;
        #endregion

        #region Ctor
        public LocalStorageServico(LocalStorage localStorage)
        {
            _localStorage = localStorage;
        }

        public void CacheAutenticacaoResponseLocalAsync(string key, AutenticacaoResponse obj)
        {
            _localStorage.Store(key, obj);
        }

        public object CacheObterAutenticacaoResponsePorKey(string key)
        {
            return _localStorage.Get<AutenticacaoResponse>(key);
        }
        #endregion
    }
}
