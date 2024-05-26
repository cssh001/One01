using ONE01.Models.Requests;
using ONE01.Models.Responses;

namespace ONE01.Repositories.Interfaces
{
    public interface ITourRepository
    {
         Task<int> CreateNewTour(TourRequest request);
         Task<bool> UpdateToure(int Id, TourRequest request);
         Task<List<TourResponse>> GetAllTours();
         Task<bool> DeleteImageDetailById (int Id);
         Task<List<TourImageResponse>> GetTourImageByTourId(int TourId);
         Task CreateNewTourImage(TourImageRequest request);
         Task<bool> DeleteTour(int Id); 

    }
}
