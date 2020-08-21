using System.Threading.Tasks;
using DatingAPI.Entities.QueryParameters;
using DatingAPI.Helpers;
using DatingAPI.Models;

namespace DatingAPI.Contracts
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<PagedList<User>> GetUsers(UserParams userParams);
        Task<User> GetUserById(int id);
    }
}