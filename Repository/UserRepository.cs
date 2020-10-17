using System.Linq;
using System.Threading.Tasks;
using DatingAPI.Contracts;
using DatingAPI.Entities;
using DatingAPI.Entities.Models;
using DatingAPI.Entities.QueryParameters;
using DatingAPI.Helpers;
using Microsoft.EntityFrameworkCore;

namespace DatingAPI.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(RepositoryContext repoContext) : base(repoContext) { }

        public async Task<PagedList<User>> GetUsers(UserParams userParams)
        {
            var users = GetAll()
                .OrderBy(on => on.Username)
                .Include(p => p.Photos)
                .AsQueryable();

            users = users.Where(x => x.Gender == userParams.Gender);

            users = users.Where(x => x.Id != userParams.UserId);

            return await PagedList<User>.CreateAsync(
                users, userParams.PageNumber, userParams.PageSize
            );
        }

        public async Task<User> GetUserById(int id)
        {
            var query = GetWhere(u => u.Id == id)
                .Include(u => u.Photos)
                .FirstOrDefaultAsync(); 
            
            // var query2 = GetAll()
            //     .Include(p => p.Photos)
            //     .FirstOrDefaultAsync(u => u.Id == id);
            
            /* Both queries generate the same SQL query, so they have the same execution speed. */
            
            return await query;
        }
    }
}