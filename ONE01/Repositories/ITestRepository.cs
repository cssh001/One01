using ONE01.Models.Responses;

namespace ONE01.Repositories
{
    public interface ITestRepository
    {
        Task UpdateCategoryAsync(int id, Category category);
    }
}
