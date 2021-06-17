<<<<<<< HEAD
﻿using System;

using MyWebServer.Server.Http;
using MyWebServer.Server.Controllers;
=======
﻿using MyWebServer.Server.Http;
using MyWebServer.Server.Controllers;
using System;
>>>>>>> ba9ce9cc7bc97caa059ea28a9c51bc5c13644b7e

namespace SIS.Controllers
{
    public class AccountController : Controller
    {
        public AccountController(HttpRequest request)
            : base(request)
        {

        }

<<<<<<< HEAD
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

        public HttpResponse AuthenticatedCheck()
        {
            if (this.User.IsAuthenticated)
            {
                return Text($"Authenticated user: {this.User.Id}");
            }

            return Text("User is not authenticated!");
        }


        public HttpResponse CookiesCheck()
=======
        public HttpResponse ActionWithCookies()
>>>>>>> ba9ce9cc7bc97caa059ea28a9c51bc5c13644b7e
        {
            const string cookieName = "My-Cookie";

            if (this.Request.Cookies.ContainsKey(cookieName))
            {
                var cookie = this.Request.Cookies[cookieName];

                return Text($"Cookies already exist - {cookie}");
            }

            this.Response.AddCookie(cookieName, "My-Value");
            this.Response.AddCookie("My-Second-Cookie", "My-Second-Value");

            return Text("Cookies set!");
        }

<<<<<<< HEAD
        public HttpResponse SessionCheck()
=======
        public HttpResponse ActionWithSession()
>>>>>>> ba9ce9cc7bc97caa059ea28a9c51bc5c13644b7e
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
