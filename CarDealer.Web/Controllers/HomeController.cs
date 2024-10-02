using CarDealer.Entity.DTOs.Cars;
using CarDealer.Service.Services.Abstractions;
using CarDealer.Service.Services.Concretes;
using CarDealer.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CarDealer.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICarService carService;

        public HomeController(ILogger<HomeController> logger, ICarService carService)
        {
            _logger = logger;
            this.carService = carService;
        }

		public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 5)
		{
			var cars = await carService.GetAllCarsWithCategoryAsync();
			var paginatedCars = cars.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
			var totalCars = cars.Count;

			var model = new CarListDto
			{
				Cars = paginatedCars,
				CurrentPage = pageNumber,
				TotalPages = (int)Math.Ceiling(totalCars / (double)pageSize),
				TotalCars = totalCars
			};

			return View(model);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> Search(string brand, string color, int? year, string category, string model, int pageNumber = 1, int pageSize = 5)
		{
			var cars = await carService.FilterCarsAsync(brand, color, year, category, model);
			var totalCars = cars.Count(); // Toplam araç sayýsý

			var paginatedCars = cars.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

			var viewModel = new CarListDto
			{
				Cars = paginatedCars,
				CurrentPage = pageNumber,
				TotalPages = (int)Math.Ceiling(totalCars / (double)pageSize),
				TotalCars = totalCars
			};

			return View("Index", viewModel);
		}


		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
