using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AnyDoubts.Domain.Repositoy;
using AnyDoubts.Domain.Model;

namespace AnyDoubts.Infra.Repository.Repositories
{
    public class QuestionRepository : GenericRepository<Question>, IQuestions
    {
    }
}
