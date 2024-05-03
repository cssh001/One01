using Dapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ONE01.Context;
using ONE01.Models.Responses;
using ONE01.Repositories;
using System.Data;

namespace ONE01.Controllers
{
    [ApiController]
    public class UserController : IUserRepository
    {
        private readonly DapperContext _context;
        public UserController(DapperContext context) => _context = context;

        [HttpGet("/")]
        public async Task<IEnumerable<User>> GetUsers()
        {
            var query = "SELECT * FROM [DB01].[dbo].[Users]";
            using var connect = _context.CreateConnection();
            var response = await connect.QueryAsync<User>(query);

            return response.ToList();
        }
        [HttpGet("/01")]
        public async Task<IEnumerable<User>> GetUserById(int userId)
        {  
            const string proc = "UserById";
            using var connect = _context.CreateConnection();
            var parameter = new { id = userId};
            var response = await connect.QueryAsync<User>(proc, param: parameter, commandType: CommandType.StoredProcedure);

           return response.ToList();
                
        }

       
    }
}
