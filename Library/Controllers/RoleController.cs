using Microsoft.AspNetCore.Mvc;

namespace Biblioteka;
public class RoleController : Controller
{
	public IActionResult SwitchRole(string role)
	{
		if (role == "Librarian" || role == "Borrower")
		{
			HttpContext.Session.SetString("UserRole", role);
			HttpContext.Session.SetInt32("UserId", 1);
		}
		return RedirectToAction("Index", "Home");
	}
}
