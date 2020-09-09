using System.Threading.Tasks;

namespace Yet.Core.Interfaces
{
    /// <summary>
    /// Tasks reponsáveis por manipular os arquivos
    /// </summary>
    public interface IArquivo
    {
        Task<bool> SalvarImagem(string pictureName, string pictureBase64);
    }
}
