using Microsoft.AspNetCore.Mvc;
using ONE01.Models.Requests;
using ONE01.Models.Responses;

namespace ONE01.Repositories.Interfaces
{
    public interface IProvinceRepository
    {
        Task<List<ProvinceResponse>> GetAllProvinces();
        Task CreateNewProvince(ProvinceRequest request);
        Task UpdateProvince(int Id, ProvinceRequest request);
        Task DeleteProvince(int Id);
    }
}
