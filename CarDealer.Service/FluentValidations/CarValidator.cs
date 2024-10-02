using CarDealer.Entity.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Service.FluentValidations
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(x => x.Brand)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Year)
                .LessThanOrEqualTo(2024)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.Kilometer)
                .NotEmpty()
                .NotNull()
                .GreaterThanOrEqualTo(0);
            RuleFor(x => x.Price)
                .NotEmpty()
                .NotNull()
                .GreaterThanOrEqualTo(0);
            RuleFor(x => x.Color)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.Model)
                .NotEmpty()
                .NotNull();
            
                

        }
    }
}
