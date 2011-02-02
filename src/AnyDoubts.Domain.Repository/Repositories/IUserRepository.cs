using AnyDoubts.Domain.Model;
using AnyDoubts.Domain.Repositoy;

namespace AnyDoubts.Domain.Repository.Repositories
{
    public interface IUserRepository : IRepository, IGenericRepository<User>
    {
    }
}