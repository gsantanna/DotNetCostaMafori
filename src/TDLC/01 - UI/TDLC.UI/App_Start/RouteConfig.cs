using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TDLC.UI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
                name: "Api",
                url: "api/{action}/{metodo}/{parametro}",
                defaults: new { controller = "api", metodo = "", parametro = "" }
                );








            ////home de publicaçoes
            routes.MapRoute(
                name: "Publicações",
                url: "comunicacao/{action}/{item}",
                defaults: new { controller = "Comunicacao", action = "Index", item = UrlParameter.Optional },
                namespaces: new[] { "TDLC.UI.Controllers" });

            routes.MapRoute(
                name: "Publicações com Cultura",
                url: "{cultura}/comunicacao/{action}/{item}",
                defaults: new { cultura = "pt_BR", controller = "Comunicacao", action = "Index", item = UrlParameter.Optional },
                namespaces: new[] { "TDLC.UI.Controllers" });

            


            routes.MapRoute(
                name: "Default",
                url: "{action}",
                defaults: new { controller = "Home", action = "Index" },
                namespaces: new[] { "TDLC.UI.Controllers" });
            
            routes.MapRoute(
                name: "Default com linguagem",
                url: "{cultura}/{action}",
                defaults: new { cultura= "pt_BR",  controller = "Home", action = "Index" },
                namespaces: new[] { "TDLC.UI.Controllers" });

            








            /*
            routes.MapRoute(
                "Langs",
                "{lang}/{controller}/{action}/{id}",
                new
                {
                    lang = "pt_BR",
                    controller = "Home",
                    action = "Index",
                    id = UrlParameter.Optional
                }, namespaces: new[] { "TDLC.UI.Controllers" }

                );*/





            /*
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "TDLC.UI.Controllers" }
            );
            */



        }




    }
}
