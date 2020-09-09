using Ardalis.GuardClauses;
using System;

namespace Yet.Core.Entidades.CatalogoAgregar
{
    /// <summary>
    /// Objeto responsável pela manipulação dos itens do catálago
    /// </summary>
    public class CatalogoItem : EntidadeBase
    {
        #region Campos
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public decimal Preco { get; private set; }
        public string ImagemUri { get; private set; }
        public int CatalogoTipoId { get; private set; }
        public CatalogoTipo CatalogoTipo { get; private set; }
        public int CatalogoMarcaId { get; private set; }
        public CatalogoMarca CatalogoMarca { get; private set; }
        #endregion

        #region Ctor
        public CatalogoItem() { }

        public CatalogoItem(int catalogoTipoId,
            int catalogoMarcaId,
            string desc,
            string nome,
            decimal preco,
            string imagemUri)
        {
            CatalogoTipoId = catalogoTipoId;
            CatalogoMarcaId = catalogoMarcaId;
            Descricao = desc;
            Nome = nome;
            Preco = preco;
            ImagemUri = imagemUri;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Atualiza detalhes do item do catálago
        /// </summary>
        /// <param name="nome">Nome do item</param>
        /// <param name="descricao">Descrição do item</param>
        /// <param name="preco">Preço do item</param>
        public void AtualizaDetalhes(string nome, string descricao, decimal preco)
        {
            Guard.Against.NullOrEmpty(nome, nameof(nome));
            Guard.Against.NullOrEmpty(descricao, nameof(descricao));
            Guard.Against.NegativeOrZero(preco, nameof(preco));

            Nome = nome;
            Descricao = descricao;
            Preco = preco;
        }

        /// <summary>
        /// Atualiza detalhes do catálago
        /// </summary>
        /// <param name="catalogoMarcaId">ID da marca do catálago</param>
        public void AtualizaMarca(int catalogoMarcaId)
        {
            Guard.Against.Zero(catalogoMarcaId, nameof(catalogoMarcaId));
            CatalogoMarcaId = catalogoMarcaId;
        }

        /// <summary>
        /// Atualiza tipo do catálago
        /// </summary>
        /// <param name="catalogoTipoId">ID da tipo do catálago</param>
        public void AtualizaTipo(int catalogoTipoId)
        {
            Guard.Against.Zero(catalogoTipoId, nameof(catalogoTipoId));
            CatalogoTipoId = catalogoTipoId;
        }

        /// <summary>
        /// Atualiza URI da imagem do catá
        /// </summary>
        /// <param name="imagemUri">URI da imagem do item do catálogo</param>
        public void AtualizaImagemUri(string imagemUri)
        {
            if (string.IsNullOrEmpty(imagemUri))
            {
                imagemUri = string.Empty;
                return;
            }
            ImagemUri = $"images\\products\\{imagemUri}?{new DateTime().Ticks}";
        }
        #endregion
    }
}
