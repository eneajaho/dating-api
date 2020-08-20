using System.Linq;
using System.Threading.Tasks;
using DatingAPI.Contracts;
using DatingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingAPI.Repository
{
    public class PhotoRepository : BaseRepository<Photo>, IPhotoRepository
    {
        public PhotoRepository(DbContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<Photo> GetPhoto(int id)
        {
            return await FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Photo> GetMainPhotoForUser(int userId)
        {
            return await GetWhere(u => u.UserId == userId).FirstOrDefaultAsync(p => p.IsMain);
        }
    }
}