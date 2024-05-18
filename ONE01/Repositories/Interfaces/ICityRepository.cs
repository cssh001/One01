using ONE01.Models.Requests;
using ONE01.Models.Responses;

namespace ONE01.Repositories.Interfaces
{
    public interface ICityRepository
    {
        Task<List<CityResponse>> GetAllCities();
        Task CreateNewCity(CityRequest request);
        Task UpdateCity(int Id,  CityRequest request);
    }
}
