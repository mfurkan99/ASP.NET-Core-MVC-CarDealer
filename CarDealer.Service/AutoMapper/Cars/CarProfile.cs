using AutoMapper;
using CarDealer.Entity.DTOs.Cars;
using CarDealer.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Service.AutoMapper.Cars
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<CarDto,Car>().ReverseMap();
            CreateMap<CarUpdateDto,Car>().ReverseMap();
			CreateMap<CarUpdateDto, CarDto>().ReverseMap();
            CreateMap<CarAddDto, Car>().ReverseMap(); 
		}
    }
}
