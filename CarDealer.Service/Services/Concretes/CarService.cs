using AutoMapper;
using CarDealer.Data.UnitOfWorks;
using CarDealer.Entity.DTOs.Cars;
using CarDealer.Entity.Entities;
using CarDealer.Service.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Service.Services.Concretes
{
    public class CarService : ICarService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CarService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task CreateCarAsync(CarAddDto carAddDto)
        {
            string imageUrl = null;

            // If an image is uploaded
            if (carAddDto.Image != null)
            {
                // Define the path where you want to store the image
                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");

                // Ensure the directory exists
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }

                // Create a unique filename for the uploaded image
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(carAddDto.Image.FileName);

                // Combine the path and the file name
                var filePath = Path.Combine(uploadPath, fileName);

                // Save the file to the specified path
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await carAddDto.Image.CopyToAsync(fileStream);
                }

                // Set the ImageUrl to the relative path of the image
                imageUrl = $"/images/{fileName}";
            }

            // Create the Car entity with the imageUrl
            var car = new Car
            {
                Brand = carAddDto.Brand,
                Model = carAddDto.Model,
                Year = carAddDto.Year,
                Price = carAddDto.Price,
                Kilometer = carAddDto.Kilometer,
                Color = carAddDto.Color,
                ImageUrl = imageUrl,  // Store the relative image path here
                CategoryId = carAddDto.CategoryId
            };

            await unitOfWork.GetRepository<Car>().AddAsync(car);
            await unitOfWork.SaveAsync();
        }

        public async Task<List<CarDto>> GetAllCarsWithCategoryAsync()
        {
         var cars = await unitOfWork.GetRepository<Car>().GetAllAsync(c=>c.Status,c=>c.Category);
            var map = mapper.Map<List<CarDto>>(cars);
            return map;

        }
		public async Task<CarDto> GetCarWithCategoryAsync(int carId)
		{
			var car = await unitOfWork.GetRepository<Car>().GetAsync(c => c.Status && c.Id == carId, c => c.Category);
			var map = mapper.Map<CarDto>(car);
			return map;

		}

		public async Task UpdateCarAsync(CarUpdateDto carUpdateDto)
		{
			var car = await unitOfWork.GetRepository<Car>().GetAsync(x=>x.Status && x.Id == carUpdateDto.Id, x=>x.Category);

            if (carUpdateDto.Image != null)
            {
                // Define the path where you want to store the image
                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");

                // Ensure the directory exists
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }

                // Create a unique filename for the uploaded image
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(carUpdateDto.Image.FileName);

                // Combine the path and the file name
                var filePath = Path.Combine(uploadPath, fileName);

                // Save the file to the specified path
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await carUpdateDto.Image.CopyToAsync(fileStream);
                }

                // Set the ImageUrl to the relative path of the image
                car.ImageUrl = $"/images/{fileName}";
            }
            else
            {
                // If no new image is provided, keep the current image URL
                car.ImageUrl = carUpdateDto.CurrentImageUrl;
            }

            mapper.Map<CarUpdateDto,Car>(carUpdateDto,car);

            await unitOfWork.GetRepository<Car>().UpdateAsync(car);
            await unitOfWork.SaveAsync();
		}

        public async Task DeleteCarAsync(int carId)
        {
            var car = await unitOfWork.GetRepository<Car>().GetByIdAsync(carId);

            car.Status = false;

            car.DeletedDate = DateTime.Now;

            await unitOfWork.GetRepository<Car>().UpdateAsync(car);
            await unitOfWork.SaveAsync();
        }

        public async Task<List<CarDto>> FilterCarsAsync(string brand, string color, int? year, string category, string model)
        {
            var cars = await unitOfWork.GetRepository<Car>().GetAllAsync(
                c => (string.IsNullOrEmpty(brand) || c.Brand == brand) &&
                     (string.IsNullOrEmpty(color) || c.Color == color) &&
                     (!year.HasValue || c.Year == year) &&
                     (string.IsNullOrEmpty(category) || c.Category.Name.ToLower().Contains(category.ToLower())) &&
                     (string.IsNullOrEmpty(model) || c.Model == model) &&
                     c.Status == true, // Added condition to filter by Status
                c => c.Category);

            var mappedCars = mapper.Map<List<CarDto>>(cars);
            return mappedCars;
        }



    }
}
