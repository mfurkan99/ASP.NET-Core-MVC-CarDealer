using CarDealer.Entity.DTOs.Categories;
using CarDealer.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Entity.DTOs.Cars
{
    public class CarDto
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public int Price { get; set; }
        public int Kilometer { get; set; }
        public string Color { get; set; }
        public string ImageUrl { get; set; }

        public DateTime CreatedDate { get; set; } 

        public CategoryDto Category { get; set; }

        public bool Status { get; set; }
    }
}
