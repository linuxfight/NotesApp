using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp_Console.Models
{
	public class Tag
	{
		public int Id { get; set; }
		public string Name { get; set; }

		[InverseProperty("Tag")]
		public List<TagNote> TagsNotes { get; set; }
	}
}
