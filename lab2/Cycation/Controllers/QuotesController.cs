using Microsoft.AspNetCore.Mvc;

namespace Cycation.Controllers;

public class QuotesController : Controller
{
	public IActionResult Index()
	{
		return View();
	}
}

