using System.ComponentModel.DataAnnotations.Schema;

namespace ASP_EF.Models
{
	public class Tag
	{
		public int Id { get; set; }
		public string Name { get; set; }

		[InverseProperty("Tag")]
		public List<TagNote> TagsNotes { get; set; }
	}
}
