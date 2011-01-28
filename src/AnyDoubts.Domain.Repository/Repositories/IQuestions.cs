using System.Collections.Generic;
using AnyDoubts.Domain.Model;

namespace AnyDoubts.Domain.Repositoy
{
    public interface IQuestions : IGenericRepository<Question>
    {
        IList<Question> FromUser(string username);
    }
}
