using System.Threading.Tasks;
using DatingAPI.Models;

namespace DatingAPI.Contracts
{
    public interface IAuthRepository
    {
        void Register(User user, string password);
        Task<User> Login(string username, string password);
        Task<bool> UserExists(string username);
    }
}