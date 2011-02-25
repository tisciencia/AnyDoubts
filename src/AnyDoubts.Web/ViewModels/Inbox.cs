using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnyDoubts.Domain.Model;

namespace AnyDoubts.Web.ViewModels
{
    public class Inbox
    {
        public IList<Question> Questions { get; set; }
    }
}