using ONE01.Models.Responses;

namespace ONE01.Repositories
{
    public interface IUserRepository
    {
        public Task<IEnumerable<User>> GetUsers();
        //public Task<User> GetUserById();
    }
}
