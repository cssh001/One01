using ONE01.Models;

namespace ONE01.Repositories.Interfaces
{
    public interface ITestRepository
    {
        Task UpdateCategoryAsync(int id, Category category);
    }
}
