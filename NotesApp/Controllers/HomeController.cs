using Microsoft.AspNetCore.Mvc;
using NotesApp.Models;
using System.Diagnostics;

using Microsoft.Data.Sqlite;

namespace NotesApp.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IConfiguration _configuration;

		public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
		{
			_logger = logger;
			_configuration = configuration;
		}

		public IActionResult Index()
		{
			//var connectionLine = _configuration.GetConnectionString("SqliteConnection");
			//var connection = new SqliteConnection(connectionLine);
			//connection.Open();
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}