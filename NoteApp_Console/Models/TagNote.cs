using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp_Console.Models
{
	public class TagNote
	{
		public int Id { get; set; }
		public int IdNote { get; set; }
		public int IdTag { get; set; }

		[ForeignKey("IdNote")]
		public Note Note { get; set; }
		[ForeignKey("IdTag")]
		public Tag Tag { get; set; }
	}
}
