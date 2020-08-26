using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OdeAComida
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");//este comando instrui para ignorar requisições para acessar arquivos reais no sistema de arquivos 
            
            routes.MapRoute(name: "Cuisine",
                url: "cuisine/{nome}",
                defaults: new { controller = "Cuisine", action = "Busca", nome = UrlParameter.Optional });
            
            routes.MapRoute(
                name: "Default",//o nome da rota serve para ser referenciado da seguinte forma: @Html.RouteLink("Default"); 
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}