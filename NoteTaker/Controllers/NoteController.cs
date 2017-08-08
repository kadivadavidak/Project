using NoteTaker.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Raven.Client;

namespace NoteTaker.Controllers
{
	public class NoteController : ApiController
	{
		private readonly IDocumentSession documentSession;

		public NoteController()
		{
			documentSession = WebApiApplication.DocumentStore.OpenSession();
		}

		[Authorize]
		[HttpGet]
		[Route("api/v1/notes")]
		public IEnumerable<Note> Get()
		{
			return documentSession.Query<Note>().ToList();
		}

		[Authorize]
		[HttpGet]
		[Route("api/v1/notes/{id}")]
		public Note Get(int id)
		{
			return documentSession.Load<Note>(id);
		}

		[Authorize]
		[HttpPost]
		[Route("api/v1/notes/")]
		public Note Save(Note note)
		{
			documentSession.Store(note);
			documentSession.SaveChanges();
			return note;
		}

		[Authorize]
		[HttpPut]
		[Route("api/v1/notes/{noteId}")]
		public void Update(int noteId, Note note)
		{
			documentSession.Store(note);
			documentSession.SaveChanges();
		}

		[Authorize]
		[HttpDelete]
		[Route("api/v1/notes/{id}")]
		public void Delete(int id)
		{
			Note note = documentSession.Load<Note>(id);
			documentSession.Delete(note);
			documentSession.SaveChanges();
        }
        
        [Authorize]
        [HttpGet]
        [Route("api/v1/notes")]
        public IEnumerable<Note> Search(string query)
        {
            return documentSession.Query<Note>().Search(u => u.Text, query).ToList();
        }

        protected override void Dispose(bool disposing)
		{
			if (disposing)
				documentSession.Dispose();
			base.Dispose(disposing);
		}
	}
}