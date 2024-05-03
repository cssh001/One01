using Microsoft.AspNetCore.Mvc;
using ONE01.Models.Requests;
using ONE01.Models.Responses;

namespace ONE01.Repositories
{
    public interface IQuizRepository
    {
        Task<IEnumerable<QuizResponse>> GetAllQuiz();
        Task<ActionResult> AddNewGameQuiz(GameQuiz gameIQ);
        Task<IActionResult> DeleteGameQuiz(int id);
    }
}
