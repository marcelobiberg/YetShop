using System.Threading.Tasks;

namespace Yet.Core.Interfaces
{
    /// <summary>
    /// Tasks reponsáveis por manipular os arquivos
    /// </summary>
    public interface IFileSystem
    {
        Task<bool> SavePicture(string pictureName, string pictureBase64);
    }
}
