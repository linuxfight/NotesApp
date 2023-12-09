using NoteApp_Console.Data;
using NoteApp_Console.Models;

internal class Program
{
	private static void Main(string[] args)
	{
		var context = new NotesContext();
		var notes = context.Notes.ToList();
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