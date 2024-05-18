using Dapper;
using ONE01.Context;
using ONE01.Models.Requests;
using ONE01.Models.Responses;
using ONE01.Repositories.Interfaces;
using System.Data;
using System.Data.Common;

namespace ONE01.Repositories
{
    public class CityRepository(DapperContext _context) : ICityRepository
    {
        public async Task CreateNewCity(CityRequest request)
        {
            try
            {
                using var connection = _context.CreateConnection();
                string proc = "[DB01].[dbo].[CreateNewCityProcedure]";
                var param = new
                {
                   request.CityName,
                   request.CityImage,
                   request.CountryId,
                };
                await connection.ExecuteAsync(proc, param: param, commandType: CommandType.StoredProcedure);
            }
            catch (DbException ex)
            {

            };
        }

        public async Task<List<CityResponse>> GetAllCities()
        {
            try
            {
                using var connection = _context.CreateConnection();
                string proc = "[DB01].[dbo].[GetAllCitiesProcedure]";
                var response = await connection.QueryAsync<CityResponse>(proc, param: null, commandType: CommandType.StoredProcedure);
                return response.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving courses.", ex);
            }
        }

        public async Task UpdateCity(int Id, CityRequest request)
        {
            try
            {
                using var connection = _context.CreateConnection();
                string proc = "[DB01].[dbo].[UpdateCityProcedure]";
                var param = new
                {
                    Id,
                   request.CityName,
                   request.CityImage,
                   request.CountryId,
                };
                await connection.ExecuteAsync(proc, param: param, commandType: CommandType.StoredProcedure);
            }
            catch (DbException ex)
            {

            };
        }
    }
}
