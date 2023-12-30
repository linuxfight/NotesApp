using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp_Console.Models
{
	public class Note
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Message { get; set; }
		public int IdUser { get; set; }
		[InverseProperty("Note")]
		public NoteAdd NoteAdd { get; set; }
		[ForeignKey("IdUser")]
		public User User { get; set; }
		[InverseProperty("Note")]
		public List<TagNote> TagsNotes { get; set; }
	}
}
