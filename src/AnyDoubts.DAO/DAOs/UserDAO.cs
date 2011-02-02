using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnyDoubts.Domain.Model;
using AnyDoubts.Domain.Repository;

namespace AnyDoubts.DAO
{
    public class UserDAO : GenericDAO<User>, IUsers
    {
    }
}
