using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebApiService
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Serviços e configuração da API da Web

            config.EnableCors(new System.Web.Http.Cors.EnableCorsAttribute("*", "*", "GET, POST, OPTIONS, PUT, DELETE"));

          

            // Rotas da API da Web
            config.MapHttpAttributeRoutes();

            //json
            //config.Formatters.Remove(config.Formatters.XmlFormatter);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
