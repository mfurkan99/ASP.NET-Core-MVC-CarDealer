using AutoMapper;
using CarDealer.Entity.DTOs.Categories;
using CarDealer.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Service.AutoMapper.Categories
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile() { 
            CreateMap<CategoryDto,Category>().ReverseMap();
        }

    }
}
