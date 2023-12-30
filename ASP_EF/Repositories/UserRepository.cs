using ASP_EF.Models;
using NotesApp_EF.Data;

namespace ASP_EF.Repositories
{
	public class UserRepository
	{
		private NotesContext _context;

		public UserRepository(NotesContext context)
		{
			_context = context;
		}

		public List<User> GetAll()
		{
			return _context.Users.ToList();
		}

		public User? Get(int id)
		{
			return _context.Users.FirstOrDefault(x => x.Id == id);
		}

		public void Add(User user)
		{
			_context.Users.Add(user);
			_context.SaveChanges();
		}

		public void Remove(int id)
		{
			var user = Get(id);
			if (user != null)
			{
				_context.Users.Remove(user);
				_context.SaveChanges();
			}
		}

		public void Update(int id, User user)
		{
			var userToUpdate = Get(id);
			if (userToUpdate != null)
			{
				userToUpdate.Name = user.Name;
				userToUpdate.Notes = user.Notes;
				_context.SaveChanges();
			}
		}
	}
}
