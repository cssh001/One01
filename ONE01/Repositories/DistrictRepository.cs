using Dapper;
using Microsoft.Data.SqlClient;
using ONE01.Context;
using ONE01.Libraries;
using ONE01.Models.Requests;
using ONE01.Models.Responses;
using ONE01.Repositories.Interfaces;
using System.Data;

namespace ONE01.Repositories
{
    public class DistrictRepository(DapperContext _context) : IDistrictRepository
    {
        private readonly DBProcedures proc = new();

        public Task<bool> CreateNewDistrict(DistrictRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteDistrict(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<DistrictResponse>> GetAllDistricts()
        {
            try
            {
                using var connection = _context.CreateConnection();
                var reponse = await connection.QueryAsync<DistrictResponse>(proc.DistrictGetAllDataProcedure(), param: null, commandType: CommandType.StoredProcedure);
                return reponse.ToList();
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Exception occurred: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }

        public Task<bool> UpdateDistrict(int Id, DistrictRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
