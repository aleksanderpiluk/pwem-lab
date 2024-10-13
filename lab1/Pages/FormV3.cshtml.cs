using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lab1.Pages;

public class FormV3Model : PageModel {
	[BindProperty]
    [Required] 
	public required String Name { get; set; }
	[BindProperty]
    [Required] 
	public required String Surname { get; set; }
	[BindProperty]
    [Required] 
	public required String Phone { get; set; }
	[BindProperty]
    [Required] 
	public required String Cat { get; set; }


	public void OnGet() {

	}

 	
	public async Task<IActionResult> OnPostAsync() {
      	await Task.Delay(500);
		return new JsonResult("https://media1.tenor.com/m/1a6RFI10-oYAAAAd/butter-dog.gif");
	}
}