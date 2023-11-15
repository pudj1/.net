using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApplication4.Pages
{
    [IgnoreAntiforgeryToken(Order = 1001)]
    public class ConsultationRegistrationModel : PageModel
    {
        [BindProperty]
        public string FullName { get; set; }

        [BindProperty]
        [EmailAddress(ErrorMessage = "Введіть коректний email")]
        public string Email { get; set; }

        [BindProperty]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DesiredDate { get; set; }

        [BindProperty]
        public string SelectedProduct { get; set; }

        public List<string> Products { get; } = new List<string> { "JavaScript", "C#", "Java", "Python", "Basics" };

        public IActionResult OnPost()
        {
            if (DesiredDate < DateTime.Now)
            {
                ModelState.AddModelError(nameof(DesiredDate), "Wrong date");
                return Page();
            }
            
            if (DesiredDate.DayOfWeek == DayOfWeek.Sunday || DesiredDate.DayOfWeek == DayOfWeek.Saturday)
            {
                ModelState.AddModelError(nameof(DesiredDate), "Consultations are not held on weekends.");
                return Page();
            }

            if (SelectedProduct == "Basics" && DesiredDate.DayOfWeek == DayOfWeek.Monday)
            {
                ModelState.AddModelError(nameof(DesiredDate), "Consultations on the \"Basics\" product are not held on Mondays");
                return Page();
            }

            return RedirectToPage("/Index",new { DesiredDate = DesiredDate, FullName = FullName, SelectedProduct  = SelectedProduct});
        }
    }
}
