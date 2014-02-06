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
			config.Routes.MapHttpRoute(
				  name: "ApiById",
				  routeTemplate: "api/{controller}/{id}",
				  defaults: new { id = RouteParameter.Optional },
				  constraints: new { id = @"^[0-9]+$" }
			  );

			config.Routes.MapHttpRoute(
				name: "ApiByName",
				routeTemplate: "api/{controller}/{action}/{name}",
				defaults: null,
				constraints: new { name = @"^[a-z]+$" }
			);

			config.Routes.MapHttpRoute(
				name: "ApiByAction",
				routeTemplate: "api/{controller}/{action}",
				defaults: new { action = "Get" }
			);
		}
	}
}
