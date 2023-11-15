using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication4.Pages
{
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class IndexModel : PageModel
    {
        public int data = 2;
        public IActionResult OnGet()
        {
            if (Request.Query["DesiredDate"].ToString() == "")
                return RedirectToPage("./ConsultationRegistration");
            return Page();
        }
        public IActionResult OnPost()
        {
            return Page();
        }
    }
}
