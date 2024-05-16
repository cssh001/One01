using ONE01.Models.Requests;
using ONE01.Models.Responses;

namespace ONE01.Repositories.Interfaces
{
    public interface ICourseRepository
    {
        Task CreateNewCourse(CourseRequest courseRequest);
        Task<List<CourseResponse>> GetAllCourses();
    }
}
