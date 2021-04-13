using System.Threading.Tasks;

namespace GcpStorageExample.CLI
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var app = new App();
            app.Setup();
            await app.RunAsync();
        }
    }
}
