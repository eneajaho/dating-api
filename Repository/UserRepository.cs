using System.Linq;
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
        public UserRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public async Task<PagedList<User>> GetUsers(UserParams userParams)
        {
            var users = GetAll().Include(p => p.Photos);
            return await PagedList<User>.CreateAsync(users, userParams.PageNumber, userParams.PageSize);
        }

        public async Task<User> GetUserById(int id)
        {
            var query1 = GetWhere(u => u.Id == id).Include(u => u.Photos).FirstOrDefaultAsync();
            var query2 = GetAll().Include(p => p.Photos).FirstOrDefaultAsync(u => u.Id == id);

            return await query1;
        }
    }
}