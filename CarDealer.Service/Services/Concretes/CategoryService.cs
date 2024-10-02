using AutoMapper;
using CarDealer.Data.UnitOfWorks;
using CarDealer.Entity.DTOs.Categories;
using CarDealer.Entity.Entities;
using CarDealer.Service.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Service.Services.Concretes
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<List<CategoryDto>> GetAllCategories()
        {
            var categories = await unitOfWork.GetRepository<Category>().GetAllAsync(x=>x.Status);
            var map = mapper.Map<List<CategoryDto>>(categories);
            return map;
        }
    }
}
