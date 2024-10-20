using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Library.Models;

namespace Library.Controllers;

public class LibrarianController : Controller
{
	private readonly ILogger<HomeController> _logger;

	public LibrarianController(ILogger<HomeController> logger)
	{
		_logger = logger;
	}


	public IActionResult Books()
	{
		return View();
	}

	public IActionResult Loans()
	{
		return View();
	}



	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
	public IActionResult Error()
	{
		return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
	}
}
