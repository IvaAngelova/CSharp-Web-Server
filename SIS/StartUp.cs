﻿using SIS.Controllers;

using System.Threading.Tasks;

using MyWebServer.Server;
using MyWebServer.Server.Controllers;

namespace SIS
{
    public class StartUp
    {
        public static async Task Main()
            => await new HttpServer(routes => routes
                .MapGet<HomeController>("/", c => c.Index())
                .MapGet<HomeController>("/ToCats", c => c.LocalRedirect())
                .MapGet<HomeController>("/softuni", c => c.ToSoftUni())
                .MapGet<AnimalsController>("/Cats", c => c.Cats())
                .MapGet<AnimalsController>("/Dogs", c => c.Dogs())
                .MapGet<AnimalsController>("/Bunnies", c => c.Bunnies())
                .MapGet<AnimalsController>("/Turtles", c => c.Turtles()))
            .Start();
    }
}
