using ASP_EF.Models;
using NotesApp_EF.Data;

namespace ASP_EF.Repositories
{
	public class NoteRepository
	{
		private NotesContext _context;

		public NoteRepository(NotesContext context)
		{
			_context = context;
		}

		public List<Note> GetAll()
		{
			return _context.Notes.ToList();
		}

		public Note? Get(int id)
		{
			return _context.Notes.FirstOrDefault(x => x.Id == id);
		}

		public void Add(Note note)
		{
			_context.Notes.Add(note);
			_context.SaveChanges();
		}

		public void Remove(int id)
		{
			var note = Get(id);
			if (note != null)
			{
				_context.Notes.Remove(note);
				_context.SaveChanges();
			}
		}

		public void Update(Note note)
		{
			var noteToUpdate = Get(note.Id);
			if (noteToUpdate != null)
			{
				noteToUpdate.Title = note.Title;
				noteToUpdate.Message = note.Message;
				noteToUpdate.User = note.User;
				noteToUpdate.TagsNotes = note.TagsNotes;
				noteToUpdate.NoteAdd = note.NoteAdd;
				noteToUpdate.IdUser = note.IdUser;
				_context.SaveChanges();
			}
		}
	}
}
