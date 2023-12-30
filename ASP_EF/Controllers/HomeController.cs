using ASP_EF.Models;
using ASP_EF.Repositories;
using Microsoft.AspNetCore.Mvc;
using NotesApp_EF.Data;
using System.Diagnostics;

namespace ASP_EF.Controllers
{
	public class HomeController : Controller
	{
		private NoteRepository _noterepository;
		private UserRepository _userrepository;

		public HomeController(NoteRepository repository, UserRepository userrepository)
		{
			_noterepository = repository;
			_userrepository = userrepository;
		}

		public IActionResult Index()
		{	
			var notes = _noterepository.GetAll();
			var users = _userrepository.GetAll();
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}
	}
}