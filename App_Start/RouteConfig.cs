using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Proyecto_AirBnb
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{resource}.config/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Inicio", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
               name: "RutaRegistro",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Account", action = "Registro", id = UrlParameter.Optional }
           );
            routes.MapRoute(
              name: "RutaLogin",
              url: "{controller}/{action}/{id}",
              defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional }
          );
            routes.MapRoute(
              name: "RutaRegistro2",
              url: "{controller}/{action}/{id}",
              defaults: new { controller = "Account", action = "CompletaRegistro", id = UrlParameter.Optional }
          );
        }
    }
}
