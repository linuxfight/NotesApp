using System.ComponentModel.DataAnnotations.Schema;

namespace ASP_EF.Models
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
