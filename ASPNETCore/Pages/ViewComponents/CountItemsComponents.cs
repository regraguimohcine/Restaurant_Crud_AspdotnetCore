using ASPNETCORE.Data;
using Microsoft.AspNetCore.Mvc;

namespace ASPNETCore.Pages.ViewComponents
{
    public class CountItemsComponents : ViewComponent
    {
        private readonly IRestaurantData IRestaurant;
        public CountItemsComponents(IRestaurantData IRestaurant)
        {
            this.IRestaurant = IRestaurant;
        }

        public IViewComponentResult Invoke() { 

            var count=IRestaurant.CountItems();
            return View(count);
        }
    }
}
