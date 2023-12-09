using Microsoft.EntityFrameworkCore;
using NoteApp_Console.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp_Console.Data
{
	public class NotesContext : DbContext
	{
		public DbSet<Note> Notes { get; set; }
		public string DbPath { get; }

		public NotesContext()
		{
			var direcory = AppDomain.CurrentDomain.BaseDirectory;
			DbPath = Path.Join(direcory, "Note.db");
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlite($"Data Source={DbPath}");
		}
	}
}
