using Autofac;
using GcpStorageExample.Data.Db.Storage;
using GcpStorageExample.Settings;
using System.Threading.Tasks;

namespace GcpStorageExample.CLI
{
    public class App
    {
        private IContainer _container;

        public void Setup()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<FileService>()
                .As<IFileService>()
                .WithParameter("storageKeyFileName", GlobalConstants.STORAGE_KEY)
                .WithParameter("bucketName", GlobalConstants.STORAGE_BUCKET_NAME)
                .WithParameter("localWorkingDirectoryName", GlobalConstants.LOCAL_WORKING_DIR);
            _container = builder.Build();
        }
    
        public async Task RunAsync()
        {
            await Task.CompletedTask;
        }
    }
}
