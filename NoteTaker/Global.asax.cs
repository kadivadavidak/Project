using Newtonsoft.Json.Serialization;
using System.Web.Http;
using System.Web.Routing;
using NoteTaker.Models;
using Raven.Client;
using Raven.Client.Document;
using Raven.Client.Embedded;

namespace NoteTaker
{
	public class WebApiApplication : System.Web.HttpApplication
	{
		private static IDocumentStore documentStore;

		public static IDocumentStore DocumentStore
		{
			get { return documentStore; }
		}

		protected void Application_Start()
		{
			GlobalConfiguration.Configure(WebApiConfig.Register);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
			documentStore = new EmbeddableDocumentStore {DataDirectory = "~\\App_Data\\Database"};
			documentStore.Conventions.DefaultQueryingConsistency = ConsistencyOptions.AlwaysWaitForNonStaleResultsAsOfLastWrite;
			documentStore.Conventions.RegisterIdConvention<UserAccount>((dbName, commands, user) => string.Format("users/{0}", user.Username));
			documentStore.Initialize();
		}
	}
}