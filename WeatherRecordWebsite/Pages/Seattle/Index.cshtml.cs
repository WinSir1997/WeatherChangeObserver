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
    public class IndexModel : PageModel
    {
        private readonly WeatherRecordWebsite.Data.WeatherContext _context;

        public IndexModel(WeatherRecordWebsite.Data.WeatherContext context)
        {
            _context = context;
        }

        public IList<Temperature> Temperature { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Temperature != null)
            {
                Temperature = await _context.Temperature.ToListAsync();
            }
        }
    }
}
