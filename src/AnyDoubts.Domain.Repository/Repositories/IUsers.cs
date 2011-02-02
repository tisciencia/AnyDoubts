using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnyDoubts.Domain.Repository;
using AnyDoubts.Domain.Model;

namespace AnyDoubts.Domain.Repository
{
    public interface IUsers : IGenericRepository<User>
    {
    }
}
