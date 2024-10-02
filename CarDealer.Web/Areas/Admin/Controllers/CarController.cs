using AutoMapper;
using CarDealer.Entity.DTOs.Cars;
using CarDealer.Entity.Entities;
using CarDealer.Service.Extensions;
using CarDealer.Service.Services.Abstractions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace CarDealer.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CarController : Controller
    {
        private readonly ICarService carService;
        private readonly ICategoryService categoryService;
		private readonly IMapper mapper;
        private readonly IValidator<Car> validator;

        public CarController(ICarService carService, ICategoryService categoryService, IMapper mapper, IValidator<Car> validator)
        {
            this.carService = carService;
            this.categoryService = categoryService;
			this.mapper = mapper;
            this.validator = validator;
        }
        public async Task<IActionResult> Index()
        {
            var cars = await carService.GetAllCarsWithCategoryAsync();
            return View(cars);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var categories = await categoryService.GetAllCategories();
            return View(new CarAddDto { Categories = categories});
        }

        [HttpPost]

        public async Task<IActionResult> Add(CarAddDto carAddDto)
        {
            var map = mapper.Map<Car>(carAddDto);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                await carService.CreateCarAsync(carAddDto);
                RedirectToAction("Index", "Car", new { Area = "Admin" });
                
            }
            else
            {
                result.AddToModelState(this.ModelState);
            }

            

            var categories = await categoryService.GetAllCategories();
            return View(new CarAddDto { Categories = categories });
        }

        [HttpGet]

        public async Task<IActionResult> Update(int CarId)
        {
            var car = await carService.GetCarWithCategoryAsync(CarId);
            var categories = await categoryService.GetAllCategories();

            var carUpdateDto = mapper.Map<CarUpdateDto>(car);
			carUpdateDto.Categories = categories;
			return View(carUpdateDto);
		}

		[HttpPost]

		public async Task<IActionResult> Update(CarUpdateDto carUpdateDto)
		{
            var map = mapper.Map< Car>(carUpdateDto);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                await carService.UpdateCarAsync(carUpdateDto);
            }
            else
            {
                result.AddToModelState(this.ModelState);
            }


            var categories = await categoryService.GetAllCategories();

            carUpdateDto.Categories = categories;

            return View(carUpdateDto);
		}

        public async Task<IActionResult> Delete(int carId)
        {
            await carService.DeleteCarAsync(carId);

            return RedirectToAction("Index", "Car", new { Area = "Admin" });
        }

	}
}
