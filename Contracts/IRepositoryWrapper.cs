using System.Threading.Tasks;

namespace DatingAPI.Contracts
{
    public interface IRepositoryWrapper
    {
        IAuthRepository Auth { get; }
        IUserRepository User { get; }
        IPhotoRepository Photo { get; }
        Task<bool> SaveAsync();
    }
}