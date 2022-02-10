using ASPNETCORE.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASPNETCore.Pages.Restaurant
{
    public class DeleteModel : PageModel
    {
        private readonly IRestaurantData IRestaurant;
        public ASPNETCORE.CORE.Restaurant Restaurant { get; set; }
        public DeleteModel(IRestaurantData IRestaurant)
        {
            this.IRestaurant = IRestaurant;
        }
        public IActionResult OnGet(int RestaurantId)
        {
            Restaurant=IRestaurant.GetRestaurantById(RestaurantId);
            if (Restaurant == null) {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(int RestaurantId) {
            Restaurant=IRestaurant.DeleteRestaurant(RestaurantId);
            IRestaurant.Commit();
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            TempData["RestaurantName"] = Restaurant.Name;
            return RedirectToPage("./List");
        }
    }
}
