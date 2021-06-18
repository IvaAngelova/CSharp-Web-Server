using System;

using MyWebServer.Server.Http;
using MyWebServer.Server.Controllers;

namespace SIS.Controllers
{
    public class HomeController : Controller
    {
        public HttpResponse Index()
            => View();

        public HttpResponse LocalRedirect() => Redirect("/Animals/Cats");

        public HttpResponse ToSoftUni() => Redirect("https://softuni.bg");

        public HttpResponse StaticFiles() => View();

        public HttpResponse Error()
            => throw new InvalidOperationException("Invalid action!");
    }
}
