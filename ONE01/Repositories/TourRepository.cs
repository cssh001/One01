using Azure.Core;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using ONE01.Context;
using ONE01.Models.Requests;
using ONE01.Models.Responses;
using ONE01.Repositories.Interfaces;
using System.Data;

namespace ONE01.Repositories
{
    public class TourRepository(DapperContext _context) : ITourRepository
    {
        public async Task<int> CreateNewTour(TourRequest request)
        {
            ArgumentNullException.ThrowIfNull(request);

            try
            {
                // Assuming _context is injected through dependency injection
                using var connection = _context.CreateConnection();
                var proc = "[DB01].[dbo].[CreateNewTourProcedure]";
                var param = new
                {
                    request.Title,
                    request.CountryId,
                    request.ProvinceId,
                    request.DistrictId,
                    request.Thumbnail,
                    request.Description,
                    request.AreaName,
                    request.Price,
                    request.MapEmbed,
                };

                await connection.ExecuteAsync(proc, param, commandType: CommandType.StoredProcedure);

                int createdTourId = await connection.QuerySingleAsync<int>("SELECT TOP 1 [Id] FROM [DB01].[dbo].[Tourses] ORDER BY [CreatedAt] DESC;");

                return createdTourId;
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Exception occurred: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error creating tour: {ex.Message}");
                throw;
            }
        }

        public async Task<List<TourResponse>> GetAllTours()
        {
            try
            {
                using var connection = _context.CreateConnection();
                const string proc = "[DB01].[dbo].[GetAllToursProcedure]";
                var reponse = await connection.QueryAsync<TourResponse>(proc, param: null, commandType: CommandType.StoredProcedure);
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
        
        public async Task<List<TourImageResponse>> GetTourImageByTourId(int TourId)
        {
            try
            {
                using var connection = _context.CreateConnection();
                const string proc = "[DB01].[dbo].[GetTourImageByTourIdProcedure]";
                var param = new { TourId };
                var reponse = await connection.QueryAsync<TourImageResponse>(proc, param, commandType: CommandType.StoredProcedure);
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

        public async Task CreateNewTourImage(TourImageRequest request)
        {
            ArgumentNullException.ThrowIfNull(request);
            try
            {

                using var connection = _context.CreateConnection();
                var proc = "[DB01].[dbo].[TourImage_CreateProcedure]";
                var param = new
                {
                   request.TourId,
                   request.ImageName,
                   request.ImageOrder
                };

                await connection.ExecuteAsync(proc, param, commandType: CommandType.StoredProcedure);
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Exception occurred: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error creating province: {ex.Message}");
                throw; // Re-throw for further handling
            }
        }

        public async Task<bool> UpdateToure(int Id, TourRequest request)
        {
            ArgumentNullException.ThrowIfNull(request);

            try
            {
                // Assuming _context is injected through dependency injection
                using var connection = _context.CreateConnection();
                var proc = "[DB01].[dbo].[Tour_UpdateProcedure]";
                var param = new
                {
                    @TourId = Id,
                    request.Title,
                    request.CountryId,
                    request.ProvinceId,
                    request.DistrictId,
                    request.Thumbnail,
                    request.Description,
                    request.AreaName,
                    request.Price,
                    request.MapEmbed,
                };

                await connection.ExecuteAsync(proc, param, commandType: CommandType.StoredProcedure);

                return true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Exception occurred: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error updating tour: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> DeleteImageDetailById(int Id)
        {
            try
            {
                using var connection = _context.CreateConnection();
                var proc = "[DB01].[dbo].[TourImages_DeleteByIdPrucedure]";
                var param = new
                {
                   Id,
                };
                await connection.ExecuteAsync(proc, param, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Exception occurred: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error updating tour: {ex.Message}");
                throw;
            }
        }
    }
}
