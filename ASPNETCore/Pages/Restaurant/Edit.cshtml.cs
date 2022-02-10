using ASPNETCORE.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASPNETCore.Pages.Restaurant
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData IRestaurant;
        private readonly IHtmlHelper ihtmlhelper;

        [BindProperty]
        public ASPNETCORE.CORE.Restaurant restaurant { get; set; }

        
        public IEnumerable<SelectListItem> SelectedType { get; set; }

        public EditModel(IRestaurantData IRestaurant,IHtmlHelper ihtmlhelper)
        {
            this.IRestaurant = IRestaurant;
            this.ihtmlhelper = ihtmlhelper;
        }
        public IActionResult OnGet(int? RestaurantId)
        {
            SelectedType = ihtmlhelper.GetEnumSelectList<ASPNETCORE.CORE.TypeOfRestaurant>();
            if (RestaurantId.HasValue) {
                restaurant = IRestaurant.GetRestaurantById((int)RestaurantId);
            }
            else
            {
                restaurant = new ASPNETCORE.CORE.Restaurant();
            }
            if (restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
 
            return Page();
        }

        public IActionResult OnPost()
        {
            restaurant.Name= Request.Form["Name"];
            restaurant.Description = Request.Form["Description"];
            restaurant.Location = Request.Form["Location"];
            restaurant.Id = int.Parse(Request.Form["Id"]);

            // if (ModelState.IsValid) {
            if (restaurant.Id == 0)
                {
                    IRestaurant.AddRestaurant(restaurant);
                    IRestaurant.Commit();
                    return RedirectToPage("./List");
                }
                else {
                    IRestaurant.UpdateRestaurant(restaurant);
                    IRestaurant.Commit();
                    return RedirectToPage("./Detail", new { RestaurantId = restaurant.Id });
                }
         //  }
            SelectedType = ihtmlhelper.GetEnumSelectList<ASPNETCORE.CORE.TypeOfRestaurant>();
            return Page();
        }
    }
}
