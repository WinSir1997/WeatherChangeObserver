using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WeatherRecordWebsite.Data;
using WeatherRecordWebsite.Models;

namespace WeatherRecordWebsite.Pages.Seattle
{
    public class DeleteModel : PageModel
    {
        private readonly WeatherRecordWebsite.Data.WeatherContext _context;

        public DeleteModel(WeatherRecordWebsite.Data.WeatherContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Temperature Temperature { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Temperature == null)
            {
                return NotFound();
            }

            var temperature = await _context.Temperature.FirstOrDefaultAsync(m => m.Id == id);

            if (temperature == null)
            {
                return NotFound();
            }
            else 
            {
                Temperature = temperature;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Temperature == null)
            {
                return NotFound();
            }
            var temperature = await _context.Temperature.FindAsync(id);

            if (temperature != null)
            {
                Temperature = temperature;
                _context.Temperature.Remove(Temperature);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
