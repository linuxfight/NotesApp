using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp_Console.Models
{
	public class NoteAdd
	{
		public int Id { get; set; }
		public string Color { get; set; }
		[ForeignKey("Id")]
		public Note Note { get; set; }
	}
}
