using Dapper;
using Microsoft.Data.SqlClient;
using ONE01.Context;
using ONE01.Models;
using ONE01.Models.Requests;
using ONE01.Models.Responses;
using ONE01.Repositories.Interfaces;
using System.Data;

namespace ONE01.Repositories
{
    public class ProvinceRepository(DapperContext _context) : IProvinceRepository
    {
        public async Task CreateNewProvince(ProvinceRequest request)
        {
            ArgumentNullException.ThrowIfNull(request);
            try
            {
               
                using var connection = _context.CreateConnection();
                var proc = "[DB01].[dbo].[CreateNewProvinceProcedure]";
                var param = new
                {
                    request.ProvinceCode,
                    request.NameEn,
                    request.NameKh, 
                    request.CountryId,
                    request.ProvinceImage, 
                };

                await connection.ExecuteAsync(proc, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error creating province: {ex.Message}");
                throw; // Re-throw for further handling
            }
           
        }

        public Task DeleteProvince(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProvinceResponse>> GetAllProvinces()
        {
            try
            {
                using var connection = _context.CreateConnection();
                const string proc = "[DB01].[dbo].[GetAllProvinceProcedure]";
                var reponse = await connection.QueryAsync<ProvinceResponse>(proc, param: null, commandType: CommandType.StoredProcedure);
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

        public async Task UpdateProvince(int Id, ProvinceRequest request)
        {
            ArgumentNullException.ThrowIfNull(request);
            try
            {

                using var connection = _context.CreateConnection();
                var proc = "[DB01].[dbo].[UpdateProvinceProcedure]";
                var param = new
                {
                    Id,
                    request.ProvinceCode,
                    request.NameEn,
                    request.NameKh,
                    request.CountryId,
                    request.ProvinceImage,
                };

                await connection.ExecuteAsync(proc, param, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error creating province: {ex.Message}");
                throw; // Re-throw for further handling
            }
        }
    }
}
