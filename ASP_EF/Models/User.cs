using System.ComponentModel.DataAnnotations.Schema;

namespace ASP_EF.Models
{
	public class User
	{
		public int Id { get; set; }
		public string Name { get; set; }
		[InverseProperty("User")]
		public List<Note> Notes { get; set; }
	}
}
