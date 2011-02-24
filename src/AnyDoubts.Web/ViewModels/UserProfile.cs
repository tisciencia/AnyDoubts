using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnyDoubts.Domain.Model;
using System.ComponentModel.DataAnnotations;

namespace AnyDoubts.Web.ViewModels
{
    public class UserProfile
    {
        public IList<Question> Questions { get; set; }
        
        [Required]
        [Display(Name = "Pergunte-me o que quiser")]        
        [StringLength(255, ErrorMessage = "Must be less than 255 characters")]
        public string NewQuestion { get; set; }
    }
}