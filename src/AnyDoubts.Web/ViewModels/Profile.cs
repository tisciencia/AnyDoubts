using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnyDoubts.Domain.Model;
using System.ComponentModel.DataAnnotations;

namespace AnyDoubts.Web.ViewModels
{
    public class Profile
    {        
        List<Question> Questions { get; set; }
        [Display(Name = "Pergunte o que quiser")]
        QuestionInput NewQuestion { get; set; }
    }
}