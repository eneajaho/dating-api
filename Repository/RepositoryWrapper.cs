using System.Threading.Tasks;
using DatingAPI.Contracts;
using DatingAPI.Entities;

namespace DatingAPI.Repository
{
    
    // RepositoryWrapper is UnitOfWork, just with another name. 
    
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly RepositoryContext _repoContext;

        public RepositoryWrapper(RepositoryContext repoContext)
        {
            _repoContext = repoContext;
        }

        private IAuthRepository _auth;
        private IUserRepository _user;
        private IPhotoRepository _photo;

        public IAuthRepository Auth => _auth ??= new AuthRepository(_repoContext);
        public IUserRepository User => _user ??= new UserRepository(_repoContext);
        public IPhotoRepository Photo => _photo ??= new PhotoRepository(_repoContext);

        public async Task<bool> SaveAsync()
        {
            return await _repoContext.SaveChangesAsync() > 0;
        }
    }
}