using ASPNETCORE.CORE;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETCORE.Data
{
    public class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext()
        {
                
        }
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options)
        :base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-PG9ORVQ;Initial Catalog=DbOne;Integrated Security=True");
        }
        //Data Source = DESKTOP - PG9ORVQ; Initial Catalog = DbOne; Integrated Security = True
        public DbSet<Restaurant> Restaurants { get; set; }

    }
}
