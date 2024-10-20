using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Library.Models;
using Library.Services;
using Library.Repositories;
using System.ComponentModel;

namespace Library.Controllers;

public class BorrowerController : Controller
{
	private readonly ILogger<BorrowerController> _logger;
	private readonly JsonService JsonService;
	private readonly LibraryRepository LibraryRepository;

	public BorrowerController(ILogger<BorrowerController> logger, JsonService jsonService, LibraryRepository libraryRepository)
	{
		_logger = logger;
		JsonService = jsonService;
		LibraryRepository = libraryRepository;
	}

	[HttpGet]

	public IActionResult Borrow([FromQuery] string text, [FromQuery] int type = 3)
	{
		if (text == null || text.Length == 0)
			return View(new List<BookModel>());


		return View(LibraryRepository.GetFilteredBooks(LibraryRepository.GetBookList(), text, type));
	}



	public IActionResult Loans()
	{
		int userId = HttpContext.Session.GetInt32("UserId") ?? 1;

		return View();
	}

	public IActionResult Notifications()
	{
		return View();
	}
	public IActionResult UserProfile()
	{
		int userId = HttpContext.Session.GetInt32("UserId") ?? 1;
		UserModel? user = LibraryRepository.GetUser(userId);
		if (user == null)
		{
			return RedirectToAction("Index", "Home");
		}
		return View(user);
	}

	[HttpPost]
	public IActionResult UpdateUserProfile()
	{
		Console.WriteLine("TEST");

		return RedirectToAction("UserProfile", "Borrower");
	}



	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
	public IActionResult Error()
	{
		return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
	}
}
