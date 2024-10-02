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
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(new Category
            {
                Id = 1,
                Name = "Otomobil",
                CreatedDate = DateTime.Now,
                Status = true
            },
            new Category
            {
                Id = 2,
                Name = "Arazi, SUV & Pickup ",
                CreatedDate = DateTime.Now,
                Status = true
            },
            new Category
            {
                Id = 3,
                Name = "Motosiklet",
                CreatedDate = DateTime.Now,
                Status = true
            });
                
        }
    }
}
