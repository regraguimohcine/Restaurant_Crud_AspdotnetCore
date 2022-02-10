using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETCORE.CORE
{
    public class Restaurant
    {
        public int Id { get; set; }

        [Required,StringLength(800)]
        public string Name { get; set; }

        [Required, StringLength(800)]
        public string Description { get; set; }

        [Required, StringLength(800)]
        public string Location { get; set; }

        [Required]
        public TypeOfRestaurant Type { get; set; }

        public Restaurant(int Id,string Name,string Description,string Location,TypeOfRestaurant Type)
        {
            this.Id = Id;
            this.Name = Name;
            this.Description = Description;
            this.Location = Location;
            this.Type = Type;
        }

        public Restaurant()
        {

        }
    }
}
