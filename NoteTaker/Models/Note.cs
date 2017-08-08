using System;

namespace NoteTaker.Models
{
	public class Note
	{
		public Note()
		{
			CreatedTs = DateTime.Now;
		}
		public int Id { get; set; }
		public string Text { get; set; }
		public DateTime? CreatedTs { get; private set; }
	}
}