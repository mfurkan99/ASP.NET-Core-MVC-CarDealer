using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Entity.DTOs.Cars
{
	public class CarListDto
	{
		public List<CarDto> Cars { get; set; }
		public int CurrentPage { get; set; }
		public int TotalPages { get; set; }

		public int TotalCars { get; set; }
	}
}
