using CarDealer.Entity.DTOs.Cars;
using CarDealer.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Service.Services.Abstractions
{
    public interface ICarService
    {
        Task<List<CarDto>> GetAllCarsWithCategoryAsync();

        Task CreateCarAsync(CarAddDto carAddDto);

        Task<CarDto> GetCarWithCategoryAsync(int carId);

        Task UpdateCarAsync(CarUpdateDto carUpdateDto);

        Task DeleteCarAsync(int carId);

        Task<List<CarDto>> FilterCarsAsync(string brand, string color, int? year, string category, string model);



	}
}
