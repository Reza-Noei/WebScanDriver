using Newtonsoft.Json.Serialization;
using Owin;
using System.Web.Http;

namespace WebScanDriver.Service
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();

            // Enable attribute routing
            config.MapHttpAttributeRoutes();

            // Conventional routing
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Remove XML formatter
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            // Configure JSON formatter
            var json = config.Formatters.JsonFormatter;
            json.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            json.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            // Plug into OWIN pipeline
            appBuilder.UseWebApi(config);
        }
    }
}

