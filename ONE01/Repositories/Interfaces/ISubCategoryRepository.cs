using ONE01.Models;

namespace ONE01.Repositories.Interfaces
{
    public interface ISubCategoryRepository
    {
        Task<List<SubCategory>> GetAllSubCategory();
        Task CreateSubCategoryAsync(SubCategory subCategory);
        Task<IEnumerable<SubCategory>> GetSubCategoryByIdAsync(int id);
        Task UpdateSubCategory(int Id, SubCategory subCategory);
    }
}
