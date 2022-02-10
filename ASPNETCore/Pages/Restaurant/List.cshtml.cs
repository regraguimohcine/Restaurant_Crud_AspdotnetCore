using ASPNETCORE.Data;
using ASPNETCORE.CORE;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASPNETCore.Pages.Restaurant
{
    public class ListModel : PageModel
    {
        public string NameOfPage { get; set; }
        public string NameOfApp { get; set; }

        private readonly IConfiguration Config;
        private readonly IRestaurantData RestaurantData;
        public IEnumerable<ASPNETCORE.CORE.Restaurant> Restaurants;

        public ListModel(IConfiguration config,IRestaurantData RestaurantData)
        {
            this.Config=config;
            this.RestaurantData=RestaurantData;
        }
        public void OnGet(string Search)
        {
            NameOfPage = "Restaurant";
            NameOfApp = Config["NameOfApp"];
            Restaurants = RestaurantData.GetRestaurantByName(Search);
        }
    }
}
