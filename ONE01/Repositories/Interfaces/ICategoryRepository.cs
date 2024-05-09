using Microsoft.AspNetCore.Mvc;
using ONE01.Models;

namespace ONE01.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task CreateCategory(Category category);
        Task<List<Category>> GetAllCategories();
        List<Category> GetCategoryById(int Id);
        Task UpdateCategory(int Id, Category category);
    }
}
