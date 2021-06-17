using System;

using MyWebServer.Server.Http;
using MyWebServer.Server.Controllers;

namespace SIS.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(HttpRequest request) 
            : base(request)
        {

        }

        public HttpResponse Index()
            => Text("Hello from my server!");

        public HttpResponse LocalRedirect() => Redirect("/Cats");

        public HttpResponse ToSoftUni() => Redirect("https://softuni.bg");

        public HttpResponse StaticFiles() => View();

        public HttpResponse Error()
            => throw new InvalidOperationException("Invalid action!");
    }
}
