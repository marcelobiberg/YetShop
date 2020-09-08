using System;
using System.IO;

namespace Yet.API.Helpers
{
    public static class ValidadorImagem
    {
        private const int ImagemMaxBytes = 512000;

        public static bool IsImagem(this byte[] arquivoPostado, string nomeArquivo)
        {
            return arquivoPostado != null && arquivoPostado.Length > 0 && arquivoPostado.Length <= ImagemMaxBytes && IsExtensaoValido(nomeArquivo);
        }

        private static bool IsExtensaoValido(string nomeArquivo)
        {
            var extension = Path.GetExtension(nomeArquivo);

            return string.Equals(extension, ".jpg", StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(extension, ".png", StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(extension, ".gif", StringComparison.OrdinalIgnoreCase) ||
                   string.Equals(extension, ".jpeg", StringComparison.OrdinalIgnoreCase);
        }
    }
}
