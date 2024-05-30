using ONE01.Models.Requests;
using ONE01.Models.Responses;

namespace ONE01.Repositories.Interfaces
{
    public interface IDistrictRepository
    {
        Task<bool> CreateNewDistrict(DistrictRequest request);
        Task<bool> UpdateDistrict(int Id, DistrictRequest request);
        Task<List<DistrictResponse>> GetAllDistricts();
        Task<bool> DeleteDistrict(int Id);
    }
}
