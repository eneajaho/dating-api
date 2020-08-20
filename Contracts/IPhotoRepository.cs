using System.Threading.Tasks;
using DatingAPI.Models;

namespace DatingAPI.Contracts
{
    public interface IPhotoRepository : IBaseRepository<Photo>
    {
        Task<Photo> GetPhoto(int id);
        Task<Photo> GetMainPhotoForUser(int userId);
    }
}