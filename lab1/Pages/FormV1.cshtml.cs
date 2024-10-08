using lab1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lab1.Pages;

public class FormV1Model : PageModel
{
    [BindProperty]
    public string Name { get; set; }
    [BindProperty]
    public string Email { get; set; }
    [BindProperty]
    public string Message { get; set; }

    private readonly ILogger<FormV1Model> _logger;

    public FormV1Model(ILogger<FormV1Model> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {   
        
    }

    public void OnPost() {
        var formV1Data = new FormV1Data {
            Name = this.Name,
            Email = this.Email,
            Message = this.Message,
        };

        ViewData["FormData"] = formV1Data;
    }
}
