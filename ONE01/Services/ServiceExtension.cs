using ONE01.Repositories.Interfaces;
using ONE01.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ONE01.Services
{
    public static class  ServiceExtension
    {
        public static void AddCustomRepositories(this IServiceCollection services)
        {
            services.AddScoped<ITestRepository, TestRepository>();
            services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
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
