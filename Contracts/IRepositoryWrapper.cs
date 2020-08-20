using System.Threading.Tasks;

namespace DatingAPI.Contracts
{
    public interface IRepositoryWrapper
    {
        IAuthRepository Auth { get; }
        IUserRepository User { get; }
        void SaveChanges();
    }
}