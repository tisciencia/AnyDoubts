using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnyDoubts.Domain.Repositoy;
using AnyDoubts.Domain.Model;

namespace AnyDoubts.DAO
{
    public class QuestionRepository : GenericDAO<Question>, IQuestions
    {
    }
}
