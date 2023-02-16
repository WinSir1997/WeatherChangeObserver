using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WeatherRecordWebsite.Data;
using WeatherRecordWebsite.Models;

namespace WeatherRecordWebsite.Pages.Seattle
{
    public class CreateModel : PageModel
    {
        private readonly WeatherRecordWebsite.Data.WeatherContext _context;

        public CreateModel(WeatherRecordWebsite.Data.WeatherContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Temperature Temperature { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Temperature == null || Temperature == null)
            {
                return Page();
            }

            _context.Temperature.Add(Temperature);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
