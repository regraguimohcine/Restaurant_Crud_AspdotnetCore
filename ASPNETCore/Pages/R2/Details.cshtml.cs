#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ASPNETCORE.CORE;
using ASPNETCORE.Data;

namespace ASPNETCore.Pages.R2
{
    public class DetailsModel : PageModel
    {
        private readonly ASPNETCORE.Data.RestaurantDbContext _context;

        public DetailsModel(ASPNETCORE.Data.RestaurantDbContext context)
        {
            _context = context;
        }

        public ASPNETCORE.CORE.Restaurant Restaurant { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Restaurant = await _context.Restaurants.FirstOrDefaultAsync(m => m.Id == id);

            if (Restaurant == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
