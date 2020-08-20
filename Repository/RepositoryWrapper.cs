using System.Threading.Tasks;
using DatingAPI.Contracts;
using DatingAPI.Entities;

namespace DatingAPI.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly RepositoryContext _repoContext;
        
        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
        
        private IAuthRepository _auth;
        private IUserRepository _user;

        public IAuthRepository Auth => _auth ??= new AuthRepository(_repoContext);
        public IUserRepository User => _user ??= new UserRepository(_repoContext);

        public void SaveChanges() 
        {
            _repoContext.SaveChanges();
        }
    }
}