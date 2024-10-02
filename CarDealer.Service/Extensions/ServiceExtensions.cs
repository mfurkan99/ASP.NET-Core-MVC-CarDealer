using CarDealer.Service.FluentValidations;
using CarDealer.Service.Services.Abstractions;
using CarDealer.Service.Services.Concretes;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Service.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection LoadServiceExtensions(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddScoped<ICarService, CarService>();
            services.AddScoped<ICategoryService, CategoryService>();

            services.AddAutoMapper(assembly);

            services.AddControllersWithViews().AddFluentValidation(opt =>
            {
                opt.RegisterValidatorsFromAssemblyContaining<CarValidator>();
                opt.DisableDataAnnotationsValidation = true;
                opt.ValidatorOptions.LanguageManager.Culture = new System.Globalization.CultureInfo("en");
            });

            return services;
        }
    }
}
