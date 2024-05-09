using Microsoft.AspNetCore.Mvc;
using ONE01.Models;
using ONE01.Models.Requests;

namespace ONE01.Repositories.Interfaces
{
    public interface IQuizRepository
    {
        Task<List<Quiz>> GetAllQuiz();
        Task<List<Quiz>> GetQuizById(int Id);
        Task CreateNewQuiz(GameQuiz quiz);
        Task<bool> UpdateQuiz (int Id, GameQuiz quiz);
    }
}
