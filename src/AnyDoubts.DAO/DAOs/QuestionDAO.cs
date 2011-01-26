using System.Linq;
using System.Collections.Generic;
using AnyDoubts.Domain.Repositoy;
using AnyDoubts.Domain.Model;

namespace AnyDoubts.DAO
{
    public class QuestionRepository : GenericDAO<Question>, IQuestions
    {
        public IList<Question> FromUser(string username)
        {
            return GetQuery().Where(c => c.IsAnswered && c.UserId == 1).ToList();
        }
    }
}
