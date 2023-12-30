using Microsoft.EntityFrameworkCore;
using NoteApp_Console.Data;
using NoteApp_Console.Models;

internal class Program
{
	private static void Main(string[] args)
	{
		var context = new NotesContext();
		//var notesAdd = context.NotesAdd.Include(nav => nav.Note).ToList();
		//var users = context.Users.ToList();
		//var notes = context.Notes.Include(nav => nav.User).ToList();
		//var users = context.Users.ToList();
		//var tags = context.Tags.ToList();
		//var tagsNotes = context.TagsNotes.ToList();
		//var tags = context.Notes.Where(x => x.Id == 1).Include(nav => nav.TagsNotes).ThenInclude(nav => nav.Tag).FirstOrDefault(x => x.Id == 1).TagsNotes.Select(x => x.Tag).ToList();
		//var notes = context.Notes.Include(nav => nav.TagsNotes).ThenInclude(nav => nav.Tag).Include(nav => nav.User).Include(nav => nav.NoteAdd).Select(x => new { Note = x, Tags = x.TagsNotes.Where(y => y.IdNote == x.Id).Select(t => t.Tag).ToList(), User = x.User, NoteAdd = x.NoteAdd }).ToList();
		//var note = context.Notes.Include(nav => nav.User).Where(x => x.Id == 1).Select(x => new { Title = x.Title, Username = x.User.Name }).FirstOrDefault();
		//var notes = context.Notes.Include(nav => nav.NoteAdd).Select(x => new { Id = x.Id, Title = x.Title, Color = x.NoteAdd.Color }).ToList();
		var notes = context.Notes.Include(nav => nav.User).Where(x => x.User.Id == 1).ToList();
	}

	public void Test(NotesContext context)
	{
		var notes = context.Notes.ToList();
		var notesAdd = context.NotesAdd.ToList();
		foreach (var item in notes)
		{
			Console.Write($"{item.Id} {item.Title}");
			var noteadd = notesAdd.FirstOrDefault(x => x.Id == item.Id);
			if (noteadd != null)
				Console.Write($" {noteadd.Color}");
			Console.WriteLine();
		}
		var result = notes.Join(
			notesAdd,
			note => note.Id,
			noteAdd => noteAdd.Id,
			(note, noteAdd) => new { Id = note.Id, Title = note.Title, Message = note.Message, Color = noteAdd.Color }
		).ToList();
		var result2 = notes.GroupJoin(
			notesAdd,
			note => note.Id,
			noteAdd => noteAdd.Id,
			(note, noteAdd) => new { Note = note, NoteAdd = noteAdd }
		).SelectMany(x => x.NoteAdd.DefaultIfEmpty(),
			(anon, noteAdd) => new { Id = anon.Note.Id, Title = anon.Note.Title, Message = anon.Note.Message, Color = noteAdd.Color }
		).ToList();
		var words = new List<string>() { "apple", "android" };
		var res1 = words.SelectMany(x => x.ToCharArray()).ToList();
		var res2 = words.Select(x => x.ToCharArray()).ToList();
		var note = new Note()
		{
			Title = "Test",
			Message = "b r u h"
		};
		context.Notes.Add(note);
		var noteToChange = context.Notes.FirstOrDefault(x => x.Id == 1);
		noteToChange.Message = "Увековечено в камне 1";
		var noteToDelete = context.Notes.OrderBy(x => x.Id).LastOrDefault();
		context.Notes.Remove(noteToDelete);
		context.SaveChanges();
	}
}