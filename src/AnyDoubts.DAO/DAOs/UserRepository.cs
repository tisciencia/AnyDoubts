using AnyDoubts.Domain.Model;
using AnyDoubts.Domain.Repository.Repositories;

namespace AnyDoubts.DAO.DAOs
{
    public class UserRepository : GenericDAO<User>, IUserRepository
    {
    }
}
