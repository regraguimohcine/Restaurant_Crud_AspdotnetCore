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
    public class IndexModel : PageModel
    {
        private readonly ASPNETCORE.Data.RestaurantDbContext _context;

        public IndexModel(ASPNETCORE.Data.RestaurantDbContext context)
        {
            _context = context;
        }

        public IList<ASPNETCORE.CORE.Restaurant> Restaurant { get;set; }

        public async Task OnGetAsync()
        {
            Restaurant = await _context.Restaurants.ToListAsync();
        }
    }
}
