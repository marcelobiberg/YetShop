using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Yet.Shared.Models
{
    public class CatalogoItem
    {
        #region Campos
        public int Id { get; set; }

        public int CatalogoTipoId { get; set; }
        public string CatalogoTipo { get; set; } = "Não configurado";

        public int CatalogoMarcadId { get; set; }
        public string CatalogMarca { get; set; } = "Não configurado";

        [Required(ErrorMessage = "O campo Nome  é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo descrição é obrigatório")]
        public string Descricao { get; set; }

        // decimal(18,2)
        [RegularExpression(@"^\d+(\.\d{0,2})*$", ErrorMessage = "O campo preço é obrigatório e deve ter positivo e com o máximo de 2 decimais")]
        [Range(0.01, 1000)]
        [DataType(DataType.Currency)]
        public decimal Preco { get; set; }

        public string ImagemUri { get; set; }
        public string ImagemBase64 { get; set; }
        public string ImagemNome { get; set; }

        private const int ImgMaxTamanhoEmBytes = 512000;
        #endregion

        public static string IsImgValid(string imagemName, string iamgemBase64)
        {
            if (string.IsNullOrEmpty(imagemName))
            {
                return "Arquivo não encontrado!";
            }
            var fileData = Convert.FromBase64String(iamgemBase64);

            if (fileData.Length <= 0)
            {
                return "File length is 0!";
            }

            if (fileData.Length > ImgMaxTamanhoEmBytes)
            {
                return "Tamanho máximo de 512kb";
            }

            if (!IsExtenssaoValida(imagemName))
            {
                return "Arquivo não é uma imagem válida ( .jpg, .png, .gif, .jpeg)";
            }

            return null;
        }

        #region Helpers
        public static async Task<string> DataToBase64(Stream stream)
        {
            byte[] bytes;
            using (var memoryStream = new MemoryStream())
            {
                await stream.CopyToAsync(memoryStream);
                bytes = memoryStream.ToArray();
            }

            string base64 = Convert.ToBase64String(bytes);

            return new MemoryStream(Encoding.UTF8.GetBytes(base64)).ToString();
        }

        private static bool IsExtenssaoValida(string fileName)
        {
            var extension = Path.GetExtension(fileName);

            return string.Equals(extension, ".jpg", StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(extension, ".png", StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(extension, ".gif", StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(extension, ".jpeg", StringComparison.OrdinalIgnoreCase);
        }
        #endregion
    }

}
