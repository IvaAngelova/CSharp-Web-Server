using MyWebServer.Server.Http;
using MyWebServer.Server.Responses;
using System.Runtime.CompilerServices;

namespace MyWebServer.Server.Controllers
{
    public abstract class Controller
    {
        protected Controller(HttpRequest request)
               => this.Request = request;

        protected HttpRequest Request { get; private init; }

        protected HttpResponse Text(string text)
            => new TextResponse(text);

        protected HttpResponse Html(string html)
             => new HtmlResponse(html);

        protected HttpResponse Redirect(string location)
            => new RedirectResponse(location);

        protected HttpResponse View([CallerMemberName] string viewName = "")
            => new ViewResponse(viewName, GetControllerName());

        private string GetControllerName()
            => this.GetType().Name.Replace(nameof(Controller), string.Empty);

        //protected HttpResponse View(string view, object model = null)
        //    => new ViewResponse(view);
    }
}
