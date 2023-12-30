using ASP_EF.Models;
using Microsoft.EntityFrameworkCore;

namespace NotesApp_EF.Data
{
	public class NotesContext : DbContext
	{
		public DbSet<Note> Notes { get; set; }
		public DbSet<NoteAdd> NotesAdd { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<Tag> Tags { get; set; }
		public DbSet<TagNote> TagsNotes { get; set; }

		private IConfiguration _configuration;

		public NotesContext(DbContextOptions<NotesContext> options) : base(options)
		{
			
		}

		/*public NotesContext(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite(_configuration.GetConnectionString("MyConnectionSqlite"));
		}*/
	}
}
