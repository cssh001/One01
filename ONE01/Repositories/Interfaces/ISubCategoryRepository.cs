using ONE01.Models;

namespace ONE01.Repositories.Interfaces
{
    public interface ISubCategoryRepository
    {
        Task<IEnumerable<SubCategory>> GetAllSubCategory();
        Task CreateSubCategoryAsync(SubCategory subCategory);
        Task<IEnumerable<SubCategory>> GetSubCategoryByIdAsync(int id);
        Task UpdateSubCategoryAsync(int Id, SubCategory subCategory);
    }
}
