using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using System;
using System.IO;
using System.Threading.Tasks;

namespace GcpStorageExample.Data.Db.Storage
{
    public class FileService : IFileService
    {
        private readonly GoogleCredential _googleCredential;
        private readonly string _bucketName;
        private readonly string _localWorkingDirectoryName;

        public FileService(
            string storageKeyFileName,
            string bucketName,
            string localWorkingDirectoryName)
        {
            _googleCredential = GoogleCredential.FromFile(storageKeyFileName ??
                throw new ArgumentNullException(nameof(storageKeyFileName)));

            _bucketName = bucketName ??
                throw new ArgumentNullException(nameof(bucketName));

            _localWorkingDirectoryName = localWorkingDirectoryName ??
                throw new ArgumentNullException(
                    nameof(localWorkingDirectoryName));
        }

        public async Task DownloadAsync(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException(nameof(fileName));
            }
            await DownloadToWorkingDirectoryAsync(fileName);
        }

        public async Task UploadAsync(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException(nameof(fileName));
            }
            await UploadFileFromWorkingDirectoryAsync(fileName);
        }

        private async Task UploadFileFromWorkingDirectoryAsync(
            string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            var storage = StorageClient.Create(_googleCredential);

            using (var fileStream = File.OpenRead(
                GetFullLocalFileName(fileName)))
            {
                await storage.UploadObjectAsync(
                    _bucketName, fileName, null, fileStream);
            }
        }

        private async Task DownloadToWorkingDirectoryAsync(
            string fileName)
        {
            var storage = StorageClient.Create(_googleCredential);

            using (var outputFile = File.OpenWrite(
                GetFullLocalFileName(fileName)))
            {
                await storage.DownloadObjectAsync(
                    _bucketName, fileName, outputFile);
            }
        }

        private string GetFullLocalFileName(string fileName)
        {
            return $"{_localWorkingDirectoryName}/{fileName}";
        }

    }
}
