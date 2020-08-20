using System.Threading.Tasks;
using DatingAPI.Contracts;
using DatingAPI.Entities;
using DatingAPI.Helpers;
using DatingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingAPI.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public async Task<PagedList<User>> GetUsers(UserParams userParams)
        {
            var users = Entity().Include(p => p.Photos);
            return await PagedList<User>.CreateAsync(users, userParams.PageNumber, userParams.PageSize);
        }

        public async Task<User> GetUserById(int id)
        {
            return await Entity()
                .Include(p => p.Photos)
                .FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}