using System.Web.Http;

namespace Spotz
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			config.MapHttpAttributeRoutes();
			config.EnableCors();

			config.Formatters.Remove(config.Formatters.XmlFormatter);
			config.Formatters.Insert(0, new CamelCaseJsonFormatter());

			//config.EnsureInitialized();
			config.Routes.MapHttpRoute(
				name: "ApiDefault",
				routeTemplate: "api/{controller}/{action}/"

			);

			config.Routes.MapHttpRoute(
				name: "Api",
				routeTemplate: "api/{controller}/{action}/{id}",
				defaults: null,
				constraints: new { id = @"^\d+$" }
			);
			
			config.Routes.MapHttpRoute(
				name: "ApiLogin",
				routeTemplate: "api/{controller}/{action}/{emailId}/{password}"
			
			);

			config.Routes.MapHttpRoute(
				name: "ApiByEmailId",
				routeTemplate: "api/{controller}/{action}/{emailId}/{verificationCode}/{newPassword}",
				defaults: new { verificationCode = RouteParameter.Optional, newPassword = RouteParameter.Optional } ,
				constraints: new { emailId = @"^[a-z]+$" }
			);
		}
	}
}
