using System.Linq;
using System.Collections.Generic;
using AnyDoubts.Domain.Repository;
using AnyDoubts.Domain.Model;

namespace AnyDoubts.DAO
{
    public class QuestionDAO : GenericDAO<Question>, IQuestions
    {
        public IList<Question> AllAnsweredByUser(string username)
        {
            return GetQuery().Where(c => c.IsAnswered && c.To.Username == username).OrderByDescending(c => c.DateCreated).ToList();
        }

        public IList<Question> Unanswered(string username)
        {
            return GetQuery().Where(c => c.IsAnswered.Equals(false) && c.To.Username == username).OrderByDescending(c => c.DateCreated).ToList();
        }

        public Question LoadByID(string id)
        {
            return GetQuery().SingleOrDefault(c => c.ID.ToString() == id);            
        }   
    }
}
