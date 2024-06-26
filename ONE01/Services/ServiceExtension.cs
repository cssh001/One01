﻿using ONE01.Repositories.Interfaces;
using ONE01.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace ONE01.Services
{
    public static class  ServiceExtension
    {
        public static void AddCustomRepositories(this IServiceCollection services)
        {
            services.AddScoped<ITestRepository, TestRepository>();
            services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
            services.TryAddScoped<IQuizRepository, QuizRepository>();
            services.TryAddScoped<ICategoryRepository, CategoryRepository>();
            services.TryAddScoped<ICourseRepository, CourseRepository>();
            services.TryAddScoped<ICityRepository, CityRepository>();
            services.TryAddScoped<IProvinceRepository, ProvinceRepository>();
            services.TryAddScoped<ITourRepository, TourRepository>();
            services.TryAddScoped<IDistrictRepository,DistrictRepository>();
        }

        public static void ConfigureJsonOptions(this IServiceCollection services)
        {
            services.Configure<JsonOptions>(options =>
            {
               options.JsonSerializerOptions.PropertyNamingPolicy = null;
               options.JsonSerializerOptions.PropertyNameCaseInsensitive = false;
            });

        }
    }
}
