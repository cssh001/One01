using Microsoft.AspNetCore.Mvc;
using ONE01.Models.Requests;
using ONE01.Models.Responses;

namespace ONE01.Repositories.Interfaces
{
    public interface IQuizRepository
    {
        Task<List<QuizResponse>> GetAllQuiz();
        Task CreateNewQuiz(GameQuiz quiz);
    }
}
