using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Security;
using NoteTaker.Models;
using Raven.Abstractions.Exceptions;
using Raven.Client;

namespace NoteTaker.Controllers
{
	public class AccountController : ApiController
	{
		private readonly IDocumentSession documentSession;

		public AccountController()
		{
			documentSession = WebApiApplication.DocumentStore.OpenSession();
			documentSession.Advanced.UseOptimisticConcurrency = true;
		}

		[HttpPost]
		[Route("api/v1/accounts/logon")]
		public HttpResponseMessage Logon([FromBody] LogonParameters logon)
		{
			var user = documentSession.Load<UserAccount>("users/" + logon.Username);
			if(user == null)
				return Request.CreateResponse(HttpStatusCode.Forbidden, new { message = "The user name or password provided is incorrect." });

			if(!user.VerifyPassword(logon.Password))
				return Request.CreateResponse(HttpStatusCode.Forbidden, new { message = "The user name or password provided is incorrect." });

			FormsAuthentication.SetAuthCookie(user.Username, false);
			return Request.CreateResponse(HttpStatusCode.OK);
		}

		[HttpPost]
		[Route("api/v1/accounts/save")]
		//returns nothing if account created OK
		public dynamic Save([FromBody] CreateUserParameters newUser)
		{
			// Attempt to register the user
			try
			{
				var user = UserAccount.Create(newUser.Username, newUser.Password);
				documentSession.Store(user);
				documentSession.SaveChanges();
				FormsAuthentication.SetAuthCookie(newUser.Username, false /* createPersistentCookie */);
				return null;
			}
			catch (ConcurrencyException)
			{
				return Request.CreateResponse(HttpStatusCode.Conflict, new { error = "User name already exists. Please enter a different user name." });
			}
		}

		[HttpGet]
		[Route("api/v1/accounts/logout")]
		public bool Logout()
		{
			FormsAuthentication.SignOut();
			return true;
		}

		[Authorize]
		[HttpGet]
		[Route("api/v1/accounts")]
		public dynamic Lookup()
		{
			return new {name = User.Identity.Name};
		}

	}

	public class CreateUserParameters
	{
		public string Username { get; set; }
		public string Password { get; set; }
	}
	public class LogonParameters
	{
		public string Username { get; set; }
		public string Password { get; set; }
	}
}