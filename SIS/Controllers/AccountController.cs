using System;

using MyWebServer.Server.Http;
using MyWebServer.Server.Controllers;

namespace SIS.Controllers
{
    public class AccountController : Controller
    {
        public HttpResponse Login()
        {
            var someUserId = "MyUserId";

            this.SignIn(someUserId);

            return Text("User authenticated!");
        }

        public HttpResponse Logout()
        {
            this.SignOut();

            return Text("User signed out!");
        }

        public HttpResponse AuthenticationCheck()
        {
            if (this.User.IsAuthenticated)
            {
                return Text($"Authenticated user: {this.User.Id}");
            }

            return Text("User is not authenticated!");
        }

        [Authorize]
        public HttpResponse AuthorizationCheck()
            => Text($"Current user: {this.User.Id}");

        public HttpResponse CookiesCheck()
        {
            const string cookieName = "My-Cookie";

            if (this.Request.Cookies.Contains(cookieName))
            {
                var cookie = this.Request.Cookies[cookieName];

                return Text($"Cookies already exist - {cookie}");
            }

            this.Response.Cookies.Add(cookieName, "My-Value");
            this.Response.Cookies.Add("My-Second-Cookie", "My-Second-Value");

            return Text("Cookies set!");
        }

        public HttpResponse SessionCheck()
        {
            const string currentDateKey = "CurrentDate";

            if (this.Request.Session.ContainsKey(currentDateKey))
            {
                var currentDate = this.Request.Session[currentDateKey];

                return Text($"Stored date: {currentDate}!");
            }

            this.Request.Session[currentDateKey] = DateTime.UtcNow.ToString();

            return Text($"Current date stored!");
        }
    }
}
