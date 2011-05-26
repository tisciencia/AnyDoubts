using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnyDoubts.Domain.Model;
using System.ComponentModel.DataAnnotations;

namespace AnyDoubts.Web.ViewModels
{
    public class Inbox
    {
        public IList<Question> Questions { get; set; }

        [Required]
        public string Answer { get; set; }

        public string ID { get; set; }
    }
}