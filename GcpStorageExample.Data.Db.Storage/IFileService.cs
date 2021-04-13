using System.Threading.Tasks;

namespace GcpStorageExample.Data.Db.Storage
{
    public interface IFileService
    {
        Task DownloadAsync(string fileName);
        Task UploadAsync(string fileName);
        Task DeleteAsync(string fileName);
    }
}
