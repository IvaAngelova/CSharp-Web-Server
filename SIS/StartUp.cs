using SIS.Controllers;

using System.Threading.Tasks;

using MyWebServer.Server;
using MyWebServer.Server.Controllers;
using SIS.Data;

namespace SIS
{
    public class StartUp
    {
        public static async Task Main()
            => await HttpServer.WithRoutes(routes => routes
                .MapStaticFiles()
                .MapControllers()
                .MapGet<HomeController>("/ToCats", c => c.LocalRedirect()))
            .WithServices(services => services
                .Add<IData, MyDbContext>())
            .Start();
    }
}
