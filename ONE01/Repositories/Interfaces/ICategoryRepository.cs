using Microsoft.AspNetCore.Mvc;
using ONE01.Models.Responses;

namespace ONE01.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task CreateCategory(Category category);
        Task<IEnumerable<Category>> GetAllCategories();
        Task<IActionResult> DeleteCategory(int id);
    }
}
