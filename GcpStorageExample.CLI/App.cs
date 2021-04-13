using Autofac;
using GcpStorageExample.Data.Db.Storage;
using GcpStorageExample.Settings;
using System.Threading.Tasks;

namespace GcpStorageExample.CLI
{
    public class App
    {
        private readonly IContainer _container;
        private readonly string _sampleFileName;

        public App()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<FileService>()
                .As<IFileService>()
                .WithParameter("storageKeyFileName", GlobalConstants.STORAGE_KEY)
                .WithParameter("bucketName", GlobalConstants.STORAGE_BUCKET_NAME)
                .WithParameter("localWorkingDirectoryName", GlobalConstants.LOCAL_WORKING_DIR);
            _container = builder.Build();

            _sampleFileName = "~/tmp/savaged.pdf";
        }
    
        public async Task RunAsync()
        {
            IFileService fileService;
            using (var scope = _container.BeginLifetimeScope())
            {
                fileService = scope.Resolve<IFileService>();
            }
            await fileService.UploadAsync(_sampleFileName);

            await fileService.DownloadAsync(_sampleFileName);

            await fileService.DeleteAsync(_sampleFileName);
        }
    }
}
