using CarDealer.Service.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarDealer.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    
    public class HomeController : Controller
    {
        private readonly ICarService carService;

        public HomeController(ICarService carService)
        {
            this.carService = carService;
        }
        public async Task<IActionResult> Index()
        {
            var cars = await carService.GetAllCarsWithCategoryAsync();
            return View(cars);
        }
    }
}
