using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Library.Models;

namespace Library.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var userRole = HttpContext.Session.GetString("UserRole");

        if (userRole == "Librarian")
        {
            return RedirectToAction("Books", "Librarian");
        }
        else
        {
            return RedirectToAction("UserProfile", "Borrower");
        }
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
