using System;
using System.Collections.Generic;
using System.Text;
using AnyDoubts.Domain.Model;

namespace AnyDoubts.Domain.Repositoy
{
    public interface IQuestions : IRepository, IGenericRepository<Question>
    {
        
    }
}
