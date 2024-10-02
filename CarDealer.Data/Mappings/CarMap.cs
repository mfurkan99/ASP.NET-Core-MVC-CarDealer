using CarDealer.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Data.Mappings
{
    public class CarMap : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasData(new Car
            {
                Id = 1,
                Brand = "Mercedes-Benz",
                Model = "E220d",
                Year = 2018,
                Kilometer = 45000,
                Price = 3800000,
                Color = "Siyah",
                ImageUrl = "",
                CategoryId = 1,
                CreatedDate = DateTime.Now,
                Status = true

            },
            new Car
            {
                Id = 2,
                Brand = "Land Rover",
                Model = "Range Rover",
                Year = 2020,
                Kilometer = 65000,
                Price = 10000000,
                Color = "White",
                ImageUrl = "",
                CategoryId = 2,
                CreatedDate = DateTime.Now,
                Status = true
            },

            new Car
            {
                Id = 3,
                Brand = "Audi",
                Model = "Q7",
                Year = 2018,
                Kilometer = 187000,
                Price = 4000000,
                Color = "Siyah",
                ImageUrl = "",
                CategoryId = 2,
                CreatedDate = DateTime.Now,
                Status = true

            },
            new Car
            {
                Id = 4,
                Brand = "Volvo",
                Model = "S90",
                Year = 2022,
                Kilometer = 38000,
                Price = 3500000,
                Color = "Blue",
                ImageUrl = "",
                CategoryId = 1,
                CreatedDate = DateTime.Now,
                Status = true

            },
            new Car
            {
                Id = 5,
                Brand = "BMW",
                Model = "5.20i",
                Year = 2022,
                Kilometer = 50000,
                Price = 2800000,
                Color = "Gray",
                ImageUrl = "",
                CategoryId = 1,
                CreatedDate = DateTime.Now,
                Status = true
            }

            );
        }
    }
}

