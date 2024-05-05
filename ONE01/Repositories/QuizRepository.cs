using Dapper;
using Microsoft.Data.SqlClient;
using ONE01.Context;
using ONE01.Models.Requests;
using ONE01.Models.Responses;
using ONE01.Repositories.Interfaces;
using System.Data;

namespace ONE01.Repositories
{
    public class QuizRepository(DapperContext context) : IQuizRepository
    {
        public async Task CreateNewQuiz(GameQuiz gameIQ)
        {
           
                using var connection = context.CreateConnection();
                var proc = "[DB01].[dbo].[CreateNewQuizProcedure]";
                var param = new
                {
                    gameIQ.CategoryId,
                    gameIQ.UserId,
                    gameIQ.GameName,
                    gameIQ.Title,
                    gameIQ.Question,
                    gameIQ.Image,
                    gameIQ.Options,
                    gameIQ.CorrectAnswer,
                 
                };

                await connection.ExecuteAsync(proc, param, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<QuizResponse>> GetAllQuiz()
        {
            try
            {
                using var connection = context.CreateConnection();
                const string proc = "GetAllQuizzes";
                var reponse =  await connection.QueryAsync<QuizResponse>(proc, param: null, commandType: CommandType.StoredProcedure);
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
    }
}
