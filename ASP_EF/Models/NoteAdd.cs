using System.ComponentModel.DataAnnotations.Schema;

namespace ASP_EF.Models
{
	public class NoteAdd
	{
		public int Id { get; set; }
		public string Color { get; set; }
		[ForeignKey("Id")]
		public Note Note { get; set; }
	}
}
