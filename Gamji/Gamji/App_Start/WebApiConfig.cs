using System.Web.Http;

namespace Gamji
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.EnableCors();

            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.Formatters.Insert(0, new CamelCaseJsonFormatter());

            config.EnsureInitialized();
        }
    }
}
