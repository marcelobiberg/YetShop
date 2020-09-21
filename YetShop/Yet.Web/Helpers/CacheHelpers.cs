using System;

namespace Yet.Web.Helpers
{
    public class CacheHelpers
    {
        #region Campos
        public static readonly TimeSpan DuracaoPadraoDoCache = TimeSpan.FromSeconds(30);
        private static readonly string _itemsKeyTemplate = "items-{0}-{1}-{2}-{3}";
        #endregion

        #region Métodos
        //Complex example
        //public static string GenerateCatalogItemCacheKey(int pageIndex, int itemsPage, int? brandId, int? typeId)
        //{
        //    return string.Format(_itemsKeyTemplate, pageIndex, itemsPage, brandId, typeId);
        //}
        public static string GeraAutenticacaoTokenCacheKey()
        {
            return "AutenticacaoToken";
        }
        #endregion
    }
}
