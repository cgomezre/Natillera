﻿using Natillera.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Natillera
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de Web API
            
            config.MessageHandlers.Add(new TokenValidationHandler());
            // Rutas de Web API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
