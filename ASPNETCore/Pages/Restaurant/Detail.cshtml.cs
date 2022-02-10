using ASPNETCORE.CORE;
using ASPNETCORE.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASPNETCore.Pages.Restaurant
{
    public class DetailModel : PageModel
    {
        public ASPNETCORE.CORE.Restaurant Restaurant { get; set; }

        public readonly IRestaurantData IRestaurant;

        public int number { get; set; }

        public DetailModel(IRestaurantData IRestaurant)
        {
            this.IRestaurant = IRestaurant;
        }
        public IActionResult OnGet(int RestaurantId)
        {
            Restaurant = IRestaurant.GetRestaurantById(RestaurantId);
            if (Restaurant == null) {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}
