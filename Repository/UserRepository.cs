using System;
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
                .OrderByDescending(u => u.LastActive)
                .Include(u => u.Photos)
                .AsQueryable();

            users = users.Where(x => x.Gender == userParams.Gender);

            // make sure query doesn't return authenticated user
            users = users.Where(x => x.Id != userParams.UserId);

            if (userParams.MinAge != 18 || userParams.MaxAge != 99)
            { 
                // Dob = date of birth
                var minDob = DateTime.Today.AddYears(-userParams.MaxAge - 1);
                var maxDob = DateTime.Today.AddYears(-userParams.MinAge);

                users = users.Where(x => x.Birthday >= minDob && x.Birthday <= maxDob);
            }

            if (!string.IsNullOrEmpty(userParams.OrderBy))
            {
                users = userParams.OrderBy switch
                {
                    "created" => users.OrderByDescending(u => u.CreatedAt),
                    _ => users.OrderByDescending(u => u.LastActive)
                };
            }
            
            if (!string.IsNullOrEmpty(userParams.LastActive))
            {
                users = userParams.LastActive switch
                {
                    // last active needs to be later than today minus number of days/months/years
                    "day" => users.Where(x => x.LastActive.CompareTo(DateTime.Today.AddDays(-1)) >= 0),
                    "week" => users.Where(x => x.LastActive.CompareTo(DateTime.Today.AddDays(-7)) >= 0),
                    "month" => users.Where(x => x.LastActive.CompareTo(DateTime.Today.AddMonths(-1)) >= 0),
                    "year" => users.Where(x => x.LastActive.CompareTo(DateTime.Today.AddYears(-1)) >= 0),
                    _ => users
                };
            }

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