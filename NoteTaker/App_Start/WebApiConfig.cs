using System.Web.Http;

namespace NoteTaker
{
	public class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			// Web API configuration and services

			// Web API routes
			config.MapHttpAttributeRoutes();
		}

	}
}