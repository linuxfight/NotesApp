using Microsoft.AspNetCore.Mvc;
using NotesApp.Data;

namespace NotesApp.Controllers
{
	public class NotesController : Controller
	{
		private readonly IConfiguration _configuration;
		private MyDataBase _dataBase;

		public NotesController(IConfiguration configuration)
		{
			_configuration = configuration;
			_dataBase = new MyDataBase(_configuration);
		}

		public IActionResult Index()
		{
			var table = _dataBase.GetNotes();
			return View(table);
		}

		[HttpGet]
		public IActionResult AddNote()
		{
			return View();
		}

		[HttpPost]
		public IActionResult AddNote(string title, string message)
		{
			_dataBase.AddNote(title, message);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult EditNote(int id)
		{
			var note = _dataBase.GetNote(id);
			if (note == null)
			{
				return RedirectToAction("Index");
			}
			return View(note);
		}

		[HttpPost]
		public IActionResult EditNote(int id, string title, string message)
		{
			_dataBase.EditNote(id, title, message);
			return RedirectToAction("Index");
		}

		[HttpGet]
		public IActionResult DeleteNote(int id)
		{
			_dataBase.DeleteNote(id);
			return RedirectToAction("Index");
		}
	}
}
