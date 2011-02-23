using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AnyDoubts.Web.ViewModels
{
    public class QuestionInput
    {
        [Required]
        [Display(Name = "Pergunte-me o que quiser")]
        public string Message { get; set; }
    }
}