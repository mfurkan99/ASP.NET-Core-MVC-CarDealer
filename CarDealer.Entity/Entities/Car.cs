using CarDealer.Core.Entities;
using CarDealer.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Entity.Entities
{
    public class Car : EntityBase
    {

        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public int Price { get; set; }
        public int Kilometer { get; set; }
        public string Color { get; set; }
        public string ImageUrl { get; set; } 
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}


