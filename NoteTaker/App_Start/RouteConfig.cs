using System.Web.Routing;

namespace NoteTaker
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.Ignore("{resource}.axd/{*pathInfo}");
			routes.Ignore(""); //Allow index.html to load

			routes.MapPageRoute("Default", "{*anything}", "~/index.html");
		}
	}
}