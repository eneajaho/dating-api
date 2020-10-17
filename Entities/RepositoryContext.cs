using DatingAPI.Entities.Models;
using DatingAPI.Logger;
using DatingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingAPI.Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Photo> Photos { get; set; }
    }
}