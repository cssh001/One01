using Microsoft.AspNetCore.Mvc;
using ONE01.Models.Responses;

namespace ONE01.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task CreateCategory(Category category);
        List<Category> GetAllCategories();
        List<Category> GetCategoryById(int Id);
        Task UpdateCategory(int Id, Category category);
        Task DeleteCategory(int id);
    }
}
