using Dapper;
using Microsoft.AspNetCore.Mvc;
using ONE01.Context;
using ONE01.Models;
using ONE01.Repositories.Interfaces;

namespace ONE01.Repositories
{
    public class SubCategoryRepository : ISubCategoryRepository
    {
        private readonly DapperContext _context;
        public SubCategoryRepository(DapperContext context) {
            _context = context;
        }

        public Task CreateSubCategoryAsync(SubCategory subCategory)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<SubCategory>>  GetAllSubCategory()
        {
           using var connetion = _context.CreateConnection();
            const string query = "SELECT * FROM [DB01].[dbo].[SubCategories]";
             return await connetion.QueryAsync<SubCategory>(query);
                 
        }

        public async Task<IEnumerable<SubCategory>> GetSubCategoryByIdAsync(int id)
        {
            throw new NotImplementedException();

        }

        public Task UpdateSubCategoryAsync(int Id, SubCategory subCategory)
        {
            throw new NotImplementedException();
        }
    }
}
