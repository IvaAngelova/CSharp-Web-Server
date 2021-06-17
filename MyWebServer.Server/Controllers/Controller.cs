using System.Runtime.CompilerServices;

using MyWebServer.Server.Http;
using MyWebServer.Server.Results;
<<<<<<< HEAD
using MyWebServer.Server.Identity;
=======
>>>>>>> ba9ce9cc7bc97caa059ea28a9c51bc5c13644b7e

namespace MyWebServer.Server.Controllers
{
    public abstract class Controller
    {
        private const string UserSessionKey = "AuthenticatedUserId";

        protected Controller(HttpRequest request)
        {
            this.Request = request;
<<<<<<< HEAD

            this.User = this.Request.Session.ContainsKey(UserSessionKey)
                ? new UserIdentity
                {
                    Id = this.Request.Session[UserSessionKey]
                }
                : new();
=======
            this.Response = new HttpResponse(HttpStatusCode.OK);
>>>>>>> ba9ce9cc7bc97caa059ea28a9c51bc5c13644b7e
        }

        protected HttpRequest Request { get; private init; }

<<<<<<< HEAD
        protected HttpResponse Response { get; private init; } = new HttpResponse(HttpStatusCode.OK);

        protected UserIdentity User { get; private set; }

        protected void SignIn(string userId)
        {
            this.Request.Session[UserSessionKey] = userId;
            this.User = new UserIdentity
            {
                Id = userId
            };
        }

        protected void SignOut()
        {
            this.Request.Session.Remove(UserSessionKey);
            this.User = new();
        }


        protected ActionResult Text(string text)
            => new TextResult(this.Response, text);

        protected ActionResult Html(string html)
             => new HtmlResult(this.Response, html);

        protected ActionResult Redirect(string location)
            => new RedirectResult(this.Response, location);

        protected ActionResult View([CallerMemberName] string viewName = "")
            => new ViewResult(this.Response, viewName, GetControllerName(), null);

=======
        protected HttpResponse Response { get; private init; }

        protected ActionResult Text(string text)
            => new TextResult(this.Response, text);

        protected ActionResult Html(string html)
             => new HtmlResult(this.Response, html);

        protected ActionResult Redirect(string location)
            => new RedirectResult(this.Response, location);

        protected ActionResult View([CallerMemberName] string viewName = "")
            => new ViewResult(this.Response, viewName, GetControllerName(), null);

>>>>>>> ba9ce9cc7bc97caa059ea28a9c51bc5c13644b7e
        protected ActionResult View(string viewName, object model)
            => new ViewResult(this.Response, viewName, GetControllerName(), model);

        protected ActionResult View(object model, [CallerMemberName] string viewName = "")
            => new ViewResult(this.Response, viewName, GetControllerName(), model);

        private string GetControllerName()
            => this.GetType().Name.Replace(nameof(Controller), string.Empty);
    }
}
