﻿using System;

using MyWebServer.Server.Http;
using MyWebServer.Server.Routing;

namespace MyWebServer.Server.Controllers
{
    public static class RountingTableExtensions
    {
        public static IRoutingTable MapGet<TController>(this IRoutingTable routingTable, string path, Func<TController, HttpResponse> controllerFunction)
            where TController : Controller
            => routingTable.MapGet(path, request =>
             controllerFunction(CreateController<TController>(request)));

        public static IRoutingTable MapPost<TController>(this IRoutingTable routingTable, string path, Func<TController, HttpResponse> controllerFunction)
             where TController : Controller
             => routingTable.MapPost(path, request => controllerFunction(CreateController<TController>(request)));

        private static TController CreateController<TController>(HttpRequest request)
            => (TController)Activator
                .CreateInstance(typeof(TController), new[] { request });
    }
}
