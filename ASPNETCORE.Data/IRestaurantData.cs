using ASPNETCORE.CORE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETCORE.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantByName(string name);
        Restaurant GetRestaurantById(int Id);
        Restaurant UpdateRestaurant(Restaurant SelectedRestaurnat);
        Restaurant AddRestaurant(Restaurant NewRestaurant);
        Restaurant DeleteRestaurant(int RestaurantId);
        int CountItems();
        int Commit();

    }

    public class SqlRestaurantData : IRestaurantData
    {
        private readonly RestaurantDbContext db;
        public SqlRestaurantData(RestaurantDbContext db)
        {
            this.db = db;
        }
        public Restaurant AddRestaurant(Restaurant NewRestaurant)
        {
            db.Add(NewRestaurant);
            return NewRestaurant;
        }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public int CountItems()
        {
            return db.Restaurants.Count();
        }

        public Restaurant DeleteRestaurant(int RestaurantId)
        {
            var Restaurant = GetRestaurantById(RestaurantId);
            if (Restaurant != null) {
                db.Restaurants.Remove(Restaurant);
            }
            return Restaurant;
        }

        public Restaurant GetRestaurantById(int Id)
        {
            return db.Restaurants.Find(Id);
        }

        public IEnumerable<Restaurant> GetRestaurantByName(string name)
        {
            return from r in db.Restaurants where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                   select r;
        }

        public Restaurant UpdateRestaurant(Restaurant SelectedRestaurnat)
        {
            var o = db.Restaurants.Attach(SelectedRestaurnat);
            o.State =Microsoft.EntityFrameworkCore.EntityState.Modified;
            return SelectedRestaurnat;
        }
    }
    /*
    public class InMemoryRestaurantData : IRestaurantData
    {
        public List<Restaurant> Restaurants { get; set; }

        public InMemoryRestaurantData()
        {
                Restaurants = new List<Restaurant>() { 
                    new Restaurant(1,"Lhafa","The wors restaurant in the world","Tangier",TypeOfRestaurant.Moroccan),
                    new Restaurant(2,"Mexitaurant","The wors restaurant in the world","Mexi",TypeOfRestaurant.Mexican),
                    new Restaurant(3,"Etalietaurant","The wors restaurant in the world","Etalien",TypeOfRestaurant.Italien)
                };   
        }
        public IEnumerable<Restaurant> GetRestaurantByName(string name)
        {
            return from r in Restaurants
                   where string.IsNullOrWhiteSpace(name) || r.Name.StartsWith(name)
                   orderby r.Name select r;
        }

        public Restaurant GetRestaurantById(int Id)
        {
            return Restaurants.SingleOrDefault(r => r.Id == Id);
        }

        public Restaurant DeleteRestaurant(int RestaurantId)
        {
            var Restaurant = Restaurants.SingleOrDefault(r => r.Id == RestaurantId);
            if (Restaurant != null) { 
                Restaurants.Remove(Restaurant);
            }
            return Restaurant;
        }

        public int Commit()
        {
            return 0;
        }

        Restaurant IRestaurantData.UpdateRestaurant(Restaurant SelectedRestaurant)
        {
            var restaurant = Restaurants.SingleOrDefault(r => r.Id == SelectedRestaurant.Id);
            if (restaurant != null) {
                restaurant.Name= SelectedRestaurant.Name;
                restaurant.Description= SelectedRestaurant.Description;
                restaurant.Type= SelectedRestaurant.Type;
                restaurant.Location = SelectedRestaurant.Location;
            }
            return restaurant;
        }

        public Restaurant AddRestaurant(Restaurant NewRestaurant)
        {
            NewRestaurant.Id=Restaurants.Max(r => r.Id)+1;
            Restaurants.Add(NewRestaurant);
            return NewRestaurant;
        }
    }*/
}
