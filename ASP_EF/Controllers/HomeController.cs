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
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

        [HttpGet]
        public IActionResult Login()
        {
			return View();
        }

        [HttpPost]
		public IActionResult Login(string name)
		{
			if (_userrepository.Get(name) is not null)
			{
                return RedirectToAction("Index");
			}
			else
			{
				return View();
			}
		}
	}
}