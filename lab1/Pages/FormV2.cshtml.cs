using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lab1.Pages;

public class FormV2Model : PageModel
{
    [BindProperty]
    [Required, EmailAddress]
    public string Email { get; set; }
    [Required]
    [BindProperty, MinLength(8)]
    public string Password { get; set; }

    [BindProperty, Required, Compare(nameof(Password))]
    public string Password2 { get; set; }

    private readonly ILogger<FormV1Model> _logger;

    public FormV2Model(ILogger<FormV1Model> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {   
        
    }

    public void OnPost() {

    }
}
