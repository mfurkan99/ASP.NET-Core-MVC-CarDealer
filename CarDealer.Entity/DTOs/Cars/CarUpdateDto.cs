using CarDealer.Entity.DTOs.Categories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Entity.DTOs.Cars
{
	public class CarUpdateDto
	{
		public int Id { get; set; }
		public string Brand { get; set; }
		public string Model { get; set; }
		public int Year { get; set; }

		public int Price { get; set; }
		public int Kilometer { get; set; }
		public string Color { get; set; }
        public IFormFile Image { get; set; }  
        public string ImageUrlPath { get; set; }  
        public string CurrentImageUrl { get; set; }

        public int CategoryId { get; set; }

		public IList<CategoryDto> Categories { get; set; }
	}
}
