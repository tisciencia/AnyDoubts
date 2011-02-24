﻿using System.Collections.Generic;
using AnyDoubts.Domain.Model;

namespace AnyDoubts.Domain.Repository
{
    public interface IQuestions : IGenericRepository<Question>
    {
        IList<Question> AllAnsweredByUser(string username);
        IList<Question> Unanswered(string username);        
    }
}
